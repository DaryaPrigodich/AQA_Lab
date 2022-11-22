namespace convert;

public class Converter
{
    public decimal UsdEur;
    public decimal UsdZl;
    public decimal EurUsd;
    public decimal EurZl;
    public decimal ZlUsd;
    public decimal ZlEur;
    
    public Converter(decimal usdEur, decimal usdZl, decimal eurUsd,decimal eurZl,decimal zlUsd,decimal zlEur)
    {
        this.UsdEur = usdEur;
        this.UsdZl = usdZl;
        this.EurUsd = eurUsd;
        this.EurZl = eurZl;
        this.ZlUsd = zlUsd;
        this.ZlEur = zlEur;
    }
    
    public decimal Convert(decimal sumCurrency, string userCurrency, string exchangeCurrency)
    {
        return (userCurrency, exchangeCurrency) switch
        {
            (Currencies.Usd, Currencies.Eur) => sumCurrency * UsdEur,
            (Currencies.Usd, Currencies.Zl) => sumCurrency * UsdZl,
            (Currencies.Eur, Currencies.Usd) => sumCurrency * EurUsd,
            (Currencies.Eur, Currencies.Zl) => sumCurrency * EurZl,
            (Currencies.Zl, Currencies.Usd) => sumCurrency * ZlUsd,
            _ => sumCurrency * ZlEur
        };
    }
}