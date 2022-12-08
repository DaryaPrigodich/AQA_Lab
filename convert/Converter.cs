namespace convert;

public class Converter
{
    private decimal UsdEur;
    private decimal UsdZl;
    private decimal EurUsd;
    private decimal EurZl;
    private decimal ZlUsd;
    private decimal ZlEur;
 
    public Converter(decimal usdEur, decimal usdZl, decimal eurUsd,decimal eurZl,decimal zlUsd,decimal zlEur)
    {
        UsdEur = usdEur;
        UsdZl = usdZl;
        EurUsd = eurUsd;
        EurZl = eurZl;
        ZlUsd = zlUsd;
        ZlEur = zlEur;
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

