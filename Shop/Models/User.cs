namespace Shop;

public class User
{
    public string PassportId { get; set; }
    
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public List<Product> Products { get; set; }
}
