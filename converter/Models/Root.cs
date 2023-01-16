using System.Text.Json.Serialization;

namespace converter;

public class Root
{
    [JsonPropertyName("table")]
    public string Table { get; set; }
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
    [JsonPropertyName("code")]
    public string Code { get; set; }
    [JsonPropertyName("rates")]
    public List<Rate> Rates { get; set; }
}
