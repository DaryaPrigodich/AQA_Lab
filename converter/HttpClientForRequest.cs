namespace converter;

public static class HttpClientForRequest
{
    static HttpClient client = new ();
   
    public static string SentRequestForUsd()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get, RequestUri = new Uri("http://api.nbp.pl/api/exchangerates/rates/A/USD/"),
        };
        var responseMessageForUsd = client.Send(request).Content.ReadAsStringAsync().Result;

        return responseMessageForUsd;
    }

    public static string SentRequestForEur()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get, RequestUri = new Uri("http://api.nbp.pl/api/exchangerates/rates/A/EUR/"),
        };
        var responseMessageForEur = client.Send(request).Content.ReadAsStringAsync().Result;

        return responseMessageForEur;
    }
}
