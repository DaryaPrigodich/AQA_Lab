namespace convert;

public class Program
{
   public static void Main(string[] args)
   {
      var converter = new Converter(0.22M,4.6M,0.33M,0.11M,0.66M, 1.22M);
      var result = converter.Convert(1000M, Currencies.Usd, Currencies.Zl);
      Console.WriteLine(result);
   }
}
