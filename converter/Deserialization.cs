using System.Text.Json;

namespace converter;

public static class Deserialization
{
    public static Currency.Root? DeserializeUsdCurrency()
    {
        var responseMessageForUsd = HttpClientForRequest.SentRequestForUsd();
        return JsonSerializer.Deserialize<Currency.Root>(responseMessageForUsd);
    }
    
    public static Currency.Root? DeserializeEurCurrency()
    {
        var responseMessageForEur = HttpClientForRequest.SentRequestForEur();
        return JsonSerializer.Deserialize<Currency.Root>(responseMessageForEur);
    }
}
