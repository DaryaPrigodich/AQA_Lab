namespace PhoneStore;

public static class PhoneModelSearch
{
    public static void GetPhoneModel(RootObject restoredShops, out string phoneModel)
    {
        ConsoleRepresentation.PrintSelectedPhoneModel();
        phoneModel = Console.ReadLine();

        var model = phoneModel;
        var selectedListShops =
            restoredShops.Shops.Where(s => s.Phones.Any(p => p.Model == model && p.IsAvailable));
        try
        {
            if (restoredShops.Shops.Any(p => p.Phones
                    .Any(s => s.Model == model && s.IsAvailable)))
            {
                ConsoleRepresentation.PrintShopInformation(selectedListShops);
            }
            else if (restoredShops.Shops.Any(p => p.Phones
                         .Any(s => s.Model == model && s.IsAvailable == false)))
            {
                ConsoleRepresentation.PrintPhoneNotAvailable();
            }
            else
            {
                throw new PhoneNotFoundException("The phone you entered wasn't found.");
            }
        }
        catch (PhoneNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
