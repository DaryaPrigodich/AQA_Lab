namespace PhoneStore;

public class Phone 
{
    public string Model { get; set; }
    
    public string OperationSystemType { get; set; }
    
    public string MarketLaunchDate { get; set; }
    
    public string Price { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public int ShopId { get; set; }

    public static void GetCountOfPhonesInEachShops(RootObject restoredShops)
    {
        var listShops = restoredShops.Shops;

        foreach (var shop in listShops)
        {
            var iosPhonesCount = shop.Phones.Count(p => p.OperationSystemType.Contains("IOS") && p.IsAvailable == true);
            var androidPhonesCount = shop.Phones.Count(p => p.OperationSystemType.Contains("Android") && p.IsAvailable == true);

            Console.WriteLine($"In the shop '{shop.Name}' - {shop.Description}, count of Iphone is {iosPhonesCount} and count of Android is {androidPhonesCount}.");
        }
    }
}
