namespace converter;

public class EntitySearch
{
    public static void GetCurrenciesIndices(out double usdZlIndex, out double eurZlIndex)
    {
        Deserialization.DeserializeResponse(out var usdCurrencyInformation, out var eurCurrencyInformation);
        
        usdZlIndex = usdCurrencyInformation.Rates.First().Mid;
        eurZlIndex = eurCurrencyInformation.Rates.First().Mid;
    }
}
