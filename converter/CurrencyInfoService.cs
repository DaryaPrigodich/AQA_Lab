namespace converter;

public static class CurrencyInfoService
{
    private static HttpClient _client = new ();
   
    public static void SentRequest(out string responseMessageForUsd, out string responseMessageForEur)
    {
        var requestUsdIndex = new HttpRequestMessage
        {
            Method = HttpMethod.Get, RequestUri = new Uri("http://api.nbp.pl/api/exchangerates/rates/A/USD/"),
        };
        responseMessageForUsd = _client.Send(requestUsdIndex).Content.ReadAsStringAsync().Result;

        var requestEurIndex = new HttpRequestMessage
        {
            Method = HttpMethod.Get, RequestUri = new Uri("http://api.nbp.pl/api/exchangerates/rates/A/EUR/"),
        };
        responseMessageForEur = _client.Send(requestEurIndex).Content.ReadAsStringAsync().Result;
    }
}
