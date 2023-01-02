namespace PhoneStore;

public static class ConsoleRepresentation
{
    public static void PrintSelectedPhoneModel()
    {
        Console.WriteLine("What phone do you want to buy?");
    }
    
    public static void PrintShopInformation(IEnumerable<Shop> selectedListShops)
    {
        foreach (var shop in selectedListShops)
        {
            Console.WriteLine(
                $"You can buy the selected phone model in the shop: '{shop.Name}' - {shop.Description}.");
        }
    }

    public static void PrintPhoneNotAvailable()
    {
        Console.WriteLine("This phone is out of stock. Please choose another one.");
    }
    
    public static void PrintSelectedShop(string phoneModel)
    {
        Console.WriteLine($"In which shop do you want to buy a {phoneModel}?");
    }

    public static void PrintOrderInformation(string phoneInformation)
    {
        Console.WriteLine($"Your order:\n {phoneInformation}\n The order was successfully completed!");
    }
    
}
