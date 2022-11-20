partial class Program
{
    static void Main(string[] args)
    {
        Conv usdZl = new Conv(1000M, "USD","ZL");
    }
}// на следующей строке пустой строки не хватает
public class Conv
{
    public decimal sumCurrency;
    public string userCurrency;
    public string exchangeCurrency;
    
    string Usd = "USD"; // переменные внутри класса без указания модификатора доступа по дефолту - private 
    string Eur = "EUR"; // пускай люди тратят меньше усилий на понимание нансов твоего кода - используй модификаторы доступа
    string Zl = "ZL"; // в нашем случае: private string Eur = "EUR"; ...

    public Conv(decimal sumCurrency, string userCurrency, string exchangeCurrency)
    {
        this.sumCurrency = sumCurrency;
        this.userCurrency = userCurrency;
        this.exchangeCurrency = exchangeCurrency;

        decimal result = Conver();
        Console.WriteLine(result); // просил написать метод без вывода на консоль))) 
    } // на следующей строке не хватает пустой линии
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
            case ("USD","EUR"): return sumCurrency * usdEur; // переставай использовать строковые константы. у тебя есть переменные Usd Eur Zl с этими значениями 
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
