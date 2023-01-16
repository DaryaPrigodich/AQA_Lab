using System.Text.Json;

namespace converter;

public static class Deserialization
{
    public static void DeserializeResponse(out Root UsdCurrencyInformation, out Root EurCurrencyInformation)
    {
        CurrencyInfoService.SentRequest(out var responseMessageForUsd, out var responseMessageForEur);
       
        UsdCurrencyInformation = JsonSerializer.Deserialize<Root>(responseMessageForUsd);
        EurCurrencyInformation = JsonSerializer.Deserialize<Root>(responseMessageForEur);
    }
}
