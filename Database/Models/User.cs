using System.Text.Json.Serialization;
using Database.Models.Enum;

namespace Database.Models;

public record User
{
    [JsonPropertyName("userType")] 
    public UserType UserType { get; set; }
    [JsonPropertyName("username")] 
    public string Username { get; init; } = string.Empty;
    [JsonPropertyName("password")] 
    public string Password { get; init; } = string.Empty;
};
