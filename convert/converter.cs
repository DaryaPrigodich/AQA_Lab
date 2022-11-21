
Converter converter = new  Converter(1000M,"USD","ZL",0.22M,0.46M,0.33M,0.11M,0.66M,0.44M);
Console.WriteLine(converter.Convert());

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
    public Converter(decimal sumCurrency, string userCurrency, string exchangeCurrency, decimal UsdEur, decimal UsdZl, decimal EurUsd,decimal EurZl,decimal ZlUsd,decimal ZlEur)
    {
        this.sumCurrency = sumCurrency;
        this.userCurrency = userCurrency;
        this.exchangeCurrency = exchangeCurrency;

        this.UsdEur = UsdEur;
        this.UsdZl = UsdZl;
        this.EurUsd = EurUsd;
        this.EurZl = EurZl;
        this.ZlUsd = ZlUsd;
        this.ZlEur = ZlEur;
  
    }
    public decimal Convert()
    {
    
        switch (userCurrency, exchangeCurrency)
        {
            case ("USD","EUR"): return sumCurrency * UsdEur;
                break;
            case ("USD","ZL"): return sumCurrency * UsdZl;
                break;
            case ("EUR","USD"): return sumCurrency * EurUsd;
                break;
            case ("EUR","ZL"): return sumCurrency * EurZl;
                break;
            case ("ZL","USD"): return sumCurrency * ZlUsd;
                break;
            default: return sumCurrency * ZlEur;
                break;
        }
    }
}
