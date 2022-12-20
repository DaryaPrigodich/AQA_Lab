using Bogus;

namespace Shop;

public class Factory
{
    public int ProductCount { get; set; }

    public Factory(int productCount)
    {
        ProductCount = productCount;
    }
    
    public List<User> GetUsers(int userCount)
    {
        return new Faker<User>()
            .RuleFor(u => u.PassportId, f => f.Random.AlphaNumeric(5))
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Age, f => f.Random.Int(7, 100))
            .RuleFor(u=>u.Products,GetProducts(ProductCount))
            .Generate(userCount);
    }

    public List<Product> GetProducts(int productCount)
    {
        return new Faker<Product>()
            .RuleFor(u => u.ProductId, f => f.Random.AlphaNumeric(2))
            .RuleFor(u => u.ProductName, f => f.Commerce.Product())
            .RuleFor(u => u.ProductCategory, f => f.Commerce.Categories(1)[0])
            .RuleFor(u => u.ProductPrice, f => decimal.Parse(f.Commerce.Price()))
            .Generate(productCount);
    }
}
