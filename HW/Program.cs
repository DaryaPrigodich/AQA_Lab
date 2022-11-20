partial class Program
{
    static void Main(string[] args)
    {
        Conv usdZl = new Conv(1000M, "USD","ZL");
    }
}
public class Conv
{
    public decimal sumCurrency;
    public string userCurrency;
    public string exchangeCurrency;
    
    string Usd = "USD";
    string Eur = "EUR";
    string Zl = "ZL";

    public Conv(decimal sumCurrency, string userCurrency, string exchangeCurrency)
    {
        this.sumCurrency = sumCurrency;
        this.userCurrency = userCurrency;
        this.exchangeCurrency = exchangeCurrency;

        decimal result = Conver();
        Console.WriteLine(result);
    }
    public decimal Conver()
    {
        decimal usdEur = 0.96M;
        decimal usdZl = 4.88M;
        decimal eurUsd = 1.04M;
        decimal eurZl = 4.68M;
        decimal zlUsd = 0.22M;
        decimal zlEur = 0.21M;
        
        switch (userCurrency, exchangeCurrency)
        {
            case ("USD","EUR"): return sumCurrency * usdEur;
                break;
            case ("USD","ZL"): return sumCurrency * usdZl;
                break;
            case ("EUR","USD"): return sumCurrency * eurUsd;
                break;
            case ("EUR","ZL"): return sumCurrency * eurZl;
                break;
            case ("ZL","USD"): return sumCurrency * zlUsd;
                break;
            default: return sumCurrency * zlEur;
                break;
        }
    }
}