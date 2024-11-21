using System.Text.Json.Serialization;

namespace InsellerateApi.Models;

public class DNCInsellerateLeadsResponse
{
    public DNCInsellerateLeadsResponse(string message, List<LeadResult> results)
    {
        Message = message;
        Results = results;
    }
    
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    [JsonPropertyName("results")]
    public IEnumerable<LeadResult> Results { get; set; } = [];
}

public class LeadResult(string applicationId, bool success)
{
    [JsonPropertyName("applicationId")]
    public string ApplicationId { get; set; } = applicationId;

    [JsonPropertyName("success")]
    public bool Success { get; set; } = success;
}