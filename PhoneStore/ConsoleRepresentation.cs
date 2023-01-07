using NLog;

namespace PhoneStore;

public static class ConsoleRepresentation
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    private static void AskPhoneModel()
    {
        _logger.Info("What phone do you want to buy?");
    }

    private static void PrintShopInformation(string phoneModel)
    {
        var selectedShops = EntitySearchUsingLinq.GetShopsWherePhoneModelIsAvailable(phoneModel);
        
        foreach (var shop in selectedShops)
        {
            _logger.Info($"You can buy the selected phone model in the shop: \"{shop.Name}\" - {shop.Description}.");
        }
    }

    private static void PrintPhoneNotAvailable()
    {
        _logger.Info("This phone is out of stock. Please choose another one.");
    }

    private static void AskShopName(string phoneModel)
    {
        _logger.Info($"In which shop do you want to buy a {phoneModel}?");
    }

    private static void PrintOrderInformation(string phoneModel, string shopName)
    {
        var phoneInformation = GetPhoneInformation(phoneModel, shopName);
        
        _logger.Info($"Your order:\n {phoneInformation}\n The order was successfully completed!");
    }

    public static string GetPhoneModel()
    {
        AskPhoneModel();
        var phoneModel = Console.ReadLine();

        var isPhonePresent = EntitySearchUsingLinq.VerifyIsPhoneModelPresent(phoneModel);
        var isPhoneModelAvailable = EntitySearchUsingLinq.VerifyIsPhoneModelAvailable(phoneModel);
        
        try
        {
            switch (isPhonePresent)
            {
                case true when isPhoneModelAvailable:
                    PrintShopInformation(phoneModel);
                    break;
                case true when !isPhoneModelAvailable:
                    PrintPhoneNotAvailable();
                    phoneModel = GetPhoneModel();
                    break;
                default: throw new PhoneNotFoundException("The phone you entered wasn't found.");
            }
        }
        catch (PhoneNotFoundException ex)
        {
            _logger.Error(ex.Message);
            throw;
        }
        return phoneModel;
    }

    private static string GetPhoneInformation(string phoneModel, string chosenShop)
    {
        EntitySearchUsingLinq.GetMarketLaunchDateAndPriceForPhoneModel(phoneModel);   
        
        return $"Phone model: {phoneModel},\n Market launch date: {PhoneForOrder.MarketLaunchDate},\n Shop: {chosenShop}" +
               $",\n Phone price: {PhoneForOrder.PhonePrice}.";
    }
    
    public static string GetShop(string phoneModel)
    {
        AskShopName(phoneModel);
        var shopName = Console.ReadLine();
        
        try
        {
            var existingShop = EntitySearchUsingLinq.VerifyExistingShop(shopName);
           
            if (existingShop)
            {
                PrintOrderInformation(phoneModel, shopName);
            }
            else
            {
                throw new ShopNotFoundException("The shop you entered wasn't found.");
            }
        }
        catch (ShopNotFoundException ex)
        {
            _logger.Error(ex.Message);
            throw;
        }
        return shopName;
    }
}
