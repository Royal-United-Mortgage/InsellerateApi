
using System.Text.Json.Serialization;

namespace InsellerateApi.Models;

public class StatusChangeResult
{
    [JsonPropertyName("StatusCode")]
    public int StatusCode { get; set; }
    
    [JsonPropertyName("Data")]
    public object? Data { get; set; }
    
    [JsonPropertyName("Message")]
    public string? Message { get; set; }
    
    [JsonPropertyName("Errors")]
    public object? Errors { get; set; }
    
    [JsonPropertyName("ResponseDate")]
    public DateTime ResponseDate { get; set; }
}
