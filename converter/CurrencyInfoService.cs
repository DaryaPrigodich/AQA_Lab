using System.Text.Json;

namespace converter;

public static class CurrencyInfoService
{
    private static HttpClient _client = new ();
   
    public static Root? GetInfo(string currency)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get, RequestUri = new Uri($"http://api.nbp.pl/api/exchangerates/rates/A/{currency}/"),
        };
        var responseMessage = _client.Send(request).Content.ReadAsStringAsync().Result;
        var currencyInfo = JsonSerializer.Deserialize<Root>(responseMessage);
        return currencyInfo;
    }
}
