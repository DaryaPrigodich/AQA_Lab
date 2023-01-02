namespace PhoneStore;

public static class ShopSearch
{
    public static void GetShop(string phoneModel, RootObject restoredShops, out string marketLaunchDate, out string phonePrice, out string chosenShop)
    {
        ConsoleRepresentation.PrintSelectedShop(phoneModel);
        chosenShop = Console.ReadLine();
        
        GetPhoneInformation(phoneModel, restoredShops, chosenShop, out var phoneInformation, out marketLaunchDate, out phonePrice);
        
        try
        {
            var shop = chosenShop;
            if (restoredShops.Shops.Any(s => s.Name == shop))
            {
                ConsoleRepresentation.PrintOrderInformation(phoneInformation);
            }
            else
            {
                throw new ShopNotFoundException("The shop you entered wasn't found.");
            }
        }
        catch (ShopNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    private static void GetPhoneInformation(string phoneModel, RootObject restoredShops, string chosenShop, out string phoneInformation, out string marketLaunchDate, out string phonePrice)
    {
        marketLaunchDate = restoredShops.Shops.First().Phones.Find(s => s.Model == phoneModel).MarketLaunchDate;
        phonePrice = restoredShops.Shops.First().Phones.Find(s => s.Model == phoneModel).Price;
        
        phoneInformation = $"Phone model: {phoneModel},\n Market launch date: {marketLaunchDate},\n Shop: {chosenShop},\n Phone price: {phonePrice}.";
    }
}
