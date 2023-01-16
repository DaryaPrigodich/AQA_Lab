namespace converter;

public class Program
{
   public static void Main(string[] args)
   {
       var usdInfo = CurrencyInfoService.GetInfo(Currencies.Usd);
       var eurInfo = CurrencyInfoService.GetInfo(Currencies.Eur);

       var exchangeIndices = CurrenciesDictionary.CreateDictionary(usdInfo.Rates.First().Mid,
           eurInfo.Rates.First().Mid);
       
       Converter.ConvertCurrency(exchangeIndices);
   }
}
