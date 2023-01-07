namespace PhoneStore;

public class ShopNotFoundException : Exception
{
    public ShopNotFoundException(string message)
        : base(message)
    {
    }
}
