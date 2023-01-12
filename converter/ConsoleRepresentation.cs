namespace converter;

public static class ConsoleRepresentation
{
    public static void AskExchangeSum()
    {
        Console.WriteLine("Введите сумму обмена:");
    }
    
    public static void AskConvertibleCurrency()
    {
        Console.WriteLine("Введите конвертируемую валюту(пример-\"USD\"):");
    }
    
    public static void AskCurrencyToConvert()
    {
        Console.WriteLine("Введите валюту в которую хотите конвертировать(пример-\"USD\"):");
    }
    
    public static void PrintSameCurrenciesNotAvailable()
    {
        Console.WriteLine("Нельзя использовать одну валюту.");
    }

    public static bool VerifyUsingSameCurrencies(string convertibleCurrency, string currencyToConvert)
    {
        return convertibleCurrency == currencyToConvert;
    }

    public static void PrintExchangedSum(double exchangedSum, string currencyToConvert)
    {
        Console.WriteLine($"Итоговая сумма - {exchangedSum:F} {currencyToConvert}");
    }
}
