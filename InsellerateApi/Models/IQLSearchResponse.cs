using System.Text.Json.Serialization;

namespace InsellerateApi.Models;

public class IQLSearchResponse
{
    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }

    [JsonPropertyName("data")]
    public List<Dictionary<string, object>>? Data { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("errors")]
    public object? Errors { get; set; }

    [JsonPropertyName("responseDate")]
    public DateTime ResponseDate { get; set; }
}