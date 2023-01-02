using System.Text.Json;

namespace PhoneStore;

class Program
{
    public static void Main(string[] args)
    {
        JsonAnalysis.DeserializeJsonFile(out var restoredShops);
        
        Phone.GetCountOfPhonesInEachShops(restoredShops);
       
       PhoneModelSearch.GetPhoneModel(restoredShops, out var phoneModel);
       
       ShopSearch.GetShop(phoneModel,restoredShops, out var  marketLaunchDate, out var phonePrice, out var chosenShop);

       var orderReceipt = new OrderReceipt
       {
           PhoneModel = phoneModel,
           MarketLaunchDate = marketLaunchDate,
           PhonePrice = phonePrice,
           Shop = chosenShop
       };
       
       var orderReceiptJson = JsonSerializer.Serialize<OrderReceipt>(orderReceipt);

       Console.WriteLine(orderReceiptJson);
    }
}
