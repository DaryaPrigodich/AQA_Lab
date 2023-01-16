namespace converter;

public static class Converter
{
    public static void ConvertCurrency(Dictionary<string, double> exchangeIndices)
    {
        double sumCurrency;
        try
        {
            ConsoleRepresentation.AskExchangeSum();
            sumCurrency = Convert.ToDouble(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            throw;
        }

        ConsoleRepresentation.AskConvertibleCurrency();
        var convertibleCurrency = Console.ReadLine();

        ConsoleRepresentation.AskCurrencyToConvert();
        var currencyToConvert = Console.ReadLine();

        var sameCurrencies = ConsoleRepresentation.VerifyUsingSameCurrencies(convertibleCurrency, currencyToConvert);

        if (sameCurrencies)
        {
            ConsoleRepresentation.PrintSameCurrenciesNotAvailable();
        }
        else
        {
            var exchangedSum = GetExchangedSumCurrency(sumCurrency, convertibleCurrency, currencyToConvert,exchangeIndices);
            ConsoleRepresentation.PrintExchangedSum(exchangedSum, currencyToConvert);
        }
    }

    private static double GetExchangedSumCurrency(double sumCurrency, string convertibleCurrency,
        string currencyToConvert, Dictionary<string, double> exchangeIndices)
    {
        return (convertibleCurrency, currencyToConvert) switch
        {
            (Currencies.Usd, Currencies.Eur) => sumCurrency * exchangeIndices[$"{Currencies.Usd} - {Currencies.Eur}"],
            (Currencies.Usd, Currencies.Zl) => sumCurrency * exchangeIndices[$"{Currencies.Usd} - {Currencies.Zl}"],
            (Currencies.Eur, Currencies.Usd) => sumCurrency * exchangeIndices[$"{Currencies.Eur} - {Currencies.Usd}"],
            (Currencies.Eur, Currencies.Zl) => sumCurrency * exchangeIndices[$"{Currencies.Eur} - {Currencies.Zl}"],
            (Currencies.Zl, Currencies.Usd) => sumCurrency * exchangeIndices[$"{Currencies.Zl} - {Currencies.Usd}"],
            _ => sumCurrency * exchangeIndices[$"{Currencies.Zl} - {Currencies.Eur}"]
        };
    }
}
