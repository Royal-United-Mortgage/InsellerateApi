using System.Text.Json.Serialization;

namespace InsellerateApi.Models;

public class LeadPostResult
{
    [JsonPropertyName("StatusCode")] public int StatusCode { get; set; }

    [JsonPropertyName("Data")] public List<DataItem> Data { get; set; } = new();

    [JsonPropertyName("Message")] public string? Message { get; set; }

    [JsonPropertyName("Errors")] public object? Errors { get; set; }

    [JsonPropertyName("ResponseDate")] public DateTime ResponseDate { get; set; }
}

public class DataItem
{
    [JsonPropertyName("ProspectId")] public int ProspectId { get; set; }

    [JsonPropertyName("ApplicationId")] public int ApplicationId { get; set; }
}