using System.Text.Json.Serialization;

namespace API.Models;

public record Group
{
    [JsonPropertyName("password")]
    public string Password { get; init; } = string.Empty;
}
