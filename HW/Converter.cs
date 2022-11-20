namespace HW;

public class Converter
{
    public decimal UsdEur = 0.96M;
    public decimal UsdZl = 4.88M;
    public decimal EurUsd = 1.04M;
    public decimal EurZl = 4.68M;
    public decimal ZlUsd = 0.22M;
    public decimal ZlEur = 0.21M;
        
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