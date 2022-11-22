using convert;

public class Converter
{
    public decimal sumCurrency;
    public string userCurrency;
    public string exchangeCurrency;
    
    public decimal UsdEur;
    public decimal UsdZl;
    public decimal EurUsd;
    public decimal EurZl;
    public decimal ZlUsd;
    public decimal ZlEur;
    
    public Converter(decimal UsdEur, decimal UsdZl, decimal EurUsd,decimal EurZl,decimal ZlUsd,decimal ZlEur)
    {
        this.UsdEur = UsdEur;
        this.UsdZl = UsdZl;
        this.EurUsd = EurUsd;
        this.EurZl = EurZl;
        this.ZlUsd = ZlUsd;
        this.ZlEur = ZlEur;
    }
    
    public decimal Convert(decimal sumCurrency, string userCurrency, string exchangeCurrency)
    {
    
        switch (userCurrency, exchangeCurrency)
        {
            case (Currencies.USD,Currencies.EUR): return sumCurrency * UsdEur;
                break;
            case (Currencies.USD,Currencies.ZL): return sumCurrency * UsdZl;
                break;
            case (Currencies.EUR,Currencies.USD): return sumCurrency * EurUsd;
                break;
            case (Currencies.EUR,Currencies.ZL): return sumCurrency * EurZl;
                break;
            case (Currencies.ZL,Currencies.USD): return sumCurrency * ZlUsd;
                break;
            default: return sumCurrency * ZlEur;
                break;
        }
    }
}
