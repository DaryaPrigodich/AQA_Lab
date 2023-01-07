using NLog;

namespace PhoneStore;

public static class CountOfPhones
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private const string Android = "Android";
    private const string Ios = "IOS";

    public static void GetCountOfPhonesInEachShops()
    {
        var shops = Data.RootObject.Shops;

        foreach (var shop in shops)
        {
            var iosPhonesCount = shop.Phones.Count(p => p.OperationSystemType.Contains(Ios) && p.IsAvailable);
            var androidPhonesCount = shop.Phones.Count(p => p.OperationSystemType.Contains(Android) && p.IsAvailable);

            _logger.Info($"In the shop \"{shop.Name}\" - {shop.Description}, count of Iphone is {iosPhonesCount} and count of Android is {androidPhonesCount}.");
        }
    }
}
