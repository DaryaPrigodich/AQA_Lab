using System.Text.Json;
using NLog;
using PhoneStore.Models;

namespace PhoneStore;

public static class WorkWithReceipt
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public static void CreateReceipt(string phoneModel, string shopName)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        
        using var fs = new FileStream("userOrder.json", FileMode.OpenOrCreate);
        var orderReceipt = new OrderReceipt
        {
            PhoneModel = phoneModel,
            MarketLaunchDate = PhoneForOrder.MarketLaunchDate,
            PhonePrice = PhoneForOrder.PhonePrice,
            Shop = shopName,
            Date = DateTime.Now
        };
        JsonSerializer.SerializeAsync(fs, orderReceipt, options);
        _logger.Info("Data has been saved to file");
    }
}
