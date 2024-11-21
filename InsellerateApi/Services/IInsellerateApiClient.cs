using InsellerateApi.Models;

namespace InsellerateApi.Services;

public interface IInsellerateApiClient
{
    Task<IQLSearchResponse> IQLSearchAsync(IQLQueryBuilder queryBuilder, List<InsellerateField> selectFields);
    Task ChangeStatusAsync(string applicationId, InsellerateStatus status);
    Task<IQLSearchResponse> TestConnection();
    Task PostLeadAsync(LeadPostRequest request, string leadProvider, string campaignNumber = "");
}