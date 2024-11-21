using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using InsellerateApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InsellerateApi.Services;

public class InsellerateApiClientClient : IInsellerateApiClient
{
    private readonly HttpClient _httpClient;
    private readonly InsellerateConfig _config;
    private readonly ILogger<InsellerateApiClientClient> _logger;
    private readonly IHttpClientFactory _clientFactory;
    
    public InsellerateApiClientClient(IHttpClientFactory clientFactory, IOptions<InsellerateConfig> config, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<InsellerateApiClientClient>();
        _clientFactory = clientFactory;
        var httpClient = _clientFactory.CreateClient();
        _httpClient = httpClient;
        _config = config.Value;
        
        var credentials = $"{_config.Username}:{_config.Password}";
        var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);
        _httpClient.BaseAddress = new Uri(_config.BaseUrl);
    }

    public async Task<IQLSearchResponse> IQLSearchAsync(IQLQueryBuilder queryBuilder, List<InsellerateField> selectFields)
    {
        var query = queryBuilder.Build();
        var select = string.Join(",", selectFields.Select(field => $"[{field.GetFieldId()}]"));
        var url = $"IQL?orgId={_config.OrgId}&query=({query})&select={select}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        var requestUrl = response.RequestMessage?.RequestUri?.ToString();
        _logger.LogInformation("IQL Search Response: {Response}", result);
        return await response.Content.ReadFromJsonAsync<IQLSearchResponse>() ?? throw new InvalidOperationException();
    }

    public async Task ChangeStatusAsync(string applicationId, InsellerateStatus status)
    {
        var response = await _httpClient.PostAsJsonAsync($"integration/UpdateStatusAndActivity?orgId={_config.OrgId}&applicationId={applicationId}", status.GetStatusObject());
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<StatusChangeResult>();
        if (responseContent.StatusCode != 1)
        {
            _logger.LogError("Failed to update status for Application ID: {ApplicationId}. Errors: {Errors} Message: {Message}", applicationId, responseContent.Errors, responseContent.Message);
            throw new InvalidOperationException("Failed to update status");
        }
    }

    public async Task<IQLSearchResponse> TestConnection()
    {
        var response = await _httpClient.GetAsync($@"IQL?orgId={_config.OrgId}&query=[75]=""""&select=[78]");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IQLSearchResponse>() ?? throw new InvalidOperationException();
    }
    
    public async Task PostLeadAsync(LeadPostRequest request, string leadProvider = "", string campaignNumber = "")
    {
        if (string.IsNullOrEmpty(leadProvider) && string.IsNullOrEmpty(campaignNumber))
        {
            throw new InvalidOperationException("Lead Provider or Campaign Number must be provided");
        }
        _logger.LogInformation("Posting lead to {LeadProvider}", leadProvider);
        HttpResponseMessage response;
        if (string.IsNullOrEmpty(leadProvider))
        {
            response = await SendGenericLead(request, campaignNumber);
        }
        else
        {
            response = await SendProviderRequest(request, leadProvider);
        }
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<LeadPostResult>();
        if (result is null || result.StatusCode != 1)
        {
            _logger.LogError("Failed to post lead to Insellerate. Errors: {Errors} Message: {Message}", result!.Errors, result.Message);
            throw new InvalidOperationException("Failed to post lead to Insellerate");
        }
        _logger.LogInformation("Lead posted successfully");
    }
    
    private async Task<HttpResponseMessage> SendProviderRequest (LeadPostRequest request, string provider)
    {
        var providerConfig = _config.LeadProviders.FirstOrDefault(x => x.Name == provider) ?? throw new InvalidOperationException("Lead Provider not found");
        var credentials = $"{providerConfig.Username}:{providerConfig.Password}";
        var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        var client = _clientFactory.CreateClient(providerConfig.Name);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);
        client.BaseAddress = new Uri(_config.BaseUrl);
        var requestUrl = providerConfig.Url;
        _logger.LogInformation("Client Generated for {Provider} at {Url}", provider, requestUrl);
        return await client.PostAsJsonAsync(requestUrl, request);
    }
    
    private async Task<HttpResponseMessage> SendGenericLead(LeadPostRequest request, string campaignNumber)
    {
        var requestUrl = $"integration/CampaignPost/{campaignNumber}";
        _logger.LogInformation("Posting lead to {Url}", requestUrl);
        return await _httpClient.PostAsJsonAsync(requestUrl, request);
    }
}