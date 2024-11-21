using System.Text.Json.Serialization;

namespace InsellerateApi.Models;

public class DNCInsellerateLeadsRequest
{
    public DNCInsellerateLeadsRequest()
    {
    }

    [JsonPropertyName("phoneNumber")]
    public required string PhoneNumber { get; set; }
}