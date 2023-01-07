using PhoneStore.Models;

namespace PhoneStore;

public static class EntitySearchUsingLinq
{
    public static void GetMarketLaunchDateAndPriceForPhoneModel(string phoneModel)
    {
        PhoneForOrder.MarketLaunchDate = Data.RootObject.Shops.First().Phones.Find(s => s.Model == phoneModel)!.MarketLaunchDate;
        PhoneForOrder.PhonePrice = Data.RootObject.Shops.First().Phones.Find(s => s.Model == phoneModel)!.Price;
    }

    public static bool VerifyExistingShop(string chosenShop)
    {
            return Data.RootObject.Shops.Any(s => s.Name == chosenShop);
    }

    public static IEnumerable<Shop> GetShopsWherePhoneModelIsAvailable(string phoneModel)
    {
           return Data.RootObject.Shops.Where(s => s.Phones.Any(p => p.Model == phoneModel && p.IsAvailable));
    }

    public static bool VerifyIsPhoneModelPresent(string phoneModel)
    {
        return Data.RootObject.Shops.Any(p => p.Phones.Any(s => s.Model == phoneModel));
    }
    
    public static bool VerifyIsPhoneModelAvailable(string phoneModel)
    {
        return Data.RootObject.Shops.Any(p => p.Phones.Any(s => s.Model == phoneModel && s.IsAvailable));
    }
}
