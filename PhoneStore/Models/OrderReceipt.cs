namespace PhoneStore.Models;

public class OrderReceipt
{
    public string PhoneModel { get; set; }
    
    public string MarketLaunchDate { get; set; }

    public string Shop { get; set; }

    public string PhonePrice { get; set; }
    
    public DateTime Date { get; set; }
}
