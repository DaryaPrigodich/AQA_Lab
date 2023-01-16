using System.Text.Json.Serialization;

namespace converter;

public class Rate
{
    [JsonPropertyName("no")]
    public string No { get; set; }
    [JsonPropertyName("effectiveDate")]
    public string EffectiveDate { get; set; }
    [JsonPropertyName("mid")]
    public double Mid { get; set; }
}
