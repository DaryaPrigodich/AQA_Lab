namespace converter;

public class EntitySearchUsingLinq
{
    public static double GetUsdZlIndex()
    {
        var json = Deserialization.DeserializeUsdCurrency();
        return json.rates.First().mid;
    }
    
    public static double GetEurZlIndex()
    {
        var json = Deserialization.DeserializeEurCurrency();
        return json.rates.First().mid;
    }
}
