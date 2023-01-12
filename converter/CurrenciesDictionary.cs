namespace converter;

public class CurrenciesDictionary
{
    public static Dictionary<string, double> CreateDictionary()
    {
        var usdZlIndex = EntitySearchUsingLinq.GetUsdZlIndex();
        var eurZlIndex = EntitySearchUsingLinq.GetEurZlIndex();
        var zlEurIndex = 1 / eurZlIndex;
        var zlUsdIndex = 1 / usdZlIndex;
        var eurUsdIndex = eurZlIndex / usdZlIndex;
        var usdEurIndex = usdZlIndex / eurZlIndex;
        
        var exchangeIndices = new Dictionary<string, double>
        {
            { $"{Currencies.Zl} - {Currencies.Eur}", zlEurIndex},
            { $"{Currencies.Zl} - {Currencies.Usd}", zlUsdIndex},
            { $"{Currencies.Eur} - {Currencies.Usd}", eurUsdIndex},
            { $"{Currencies.Eur} - {Currencies.Zl}", eurZlIndex},
            { $"{Currencies.Usd} - {Currencies.Zl}", usdZlIndex},
            { $"{Currencies.Usd} - {Currencies.Eur}", usdEurIndex}
        };
        return exchangeIndices;
    }
}
