namespace PhoneStore;

public class Program
{
    public static void Main(string[] args)
    {
        JsonAnalysis.DeserializeJsonFile();
        
        CountOfPhones.GetCountOfPhonesInEachShops();
       
       var phoneModel = ConsoleRepresentation.GetPhoneModel();
       
       var shopName = ConsoleRepresentation.GetShop(phoneModel);

       WorkWithReceipt.CreateReceipt(phoneModel, shopName);
    }
}
