namespace Shop;

public static class InstancesHelper
{
    private const int MaxUserAge = 100;
    private const int MinUserAge = 7;

    public static void CreateListOfBuyers(out List<User> listBuyers)
    {
        var random = new Random();
        listBuyers = new Factory(random.Next(3, 5)).GetUsers(random.Next(1, 4));
    }

    public static void VerifyCorrectUserChoice(out bool isUserChoice, out int userChoice)
    {
        var writtenUserChoice = Console.ReadLine();
        isUserChoice = int.TryParse(writtenUserChoice, out userChoice) && userChoice is >= 0 and <= 5;
    }
    
    public static void VerifyExistChosenUser(List<User> listBuyers, string nameOfBuyer, out bool existingBuyer)
    {
        existingBuyer = listBuyers.Exists(buyer => buyer.Name == nameOfBuyer);
    }
    
    public static void VerifyCorrectNewBuyerAge(out bool isAge, out int ageNewUser)
    {
        var writtenUserAge = Console.ReadLine();
        isAge = int.TryParse(writtenUserAge, out ageNewUser) && ageNewUser is > MinUserAge and < MaxUserAge;
    }
    
    public static void GetFirstMatchingBuyerByName(List<User> listBuyers, string chosenBuyer, out User selectedBuyer)
    {
        selectedBuyer = listBuyers.First(buyer => buyer.Name == chosenBuyer);
    }
    
    public static void GetSumOfBuyerCart(User selectedBuyer, out decimal selectedBuyerCartSum)
    {
        selectedBuyerCartSum = selectedBuyer.Products.Sum(product => product.ProductPrice);
    }

    public static void CreateNewProduct(out Product newProduct, string productId, string productName, decimal productPrice, string productCategory)
    {
        newProduct = new Product()
        {
            ProductId = productId, ProductName = productName, ProductPrice = productPrice,
            ProductCategory = productCategory
        };
    }

    public static void CreateNewUser(out User newUser, string idNewUser, string nameNewUser,int ageNewUser)
    {
        newUser = new User()
            { PassportId = idNewUser, Name = nameNewUser, Age = ageNewUser, Products = null };
    }
    public static void RemoveProductFromBuyerCart(User selectedBuyer, string deletedProductName)
    {
        selectedBuyer.Products.RemoveAll(product => product.ProductName == deletedProductName);
    }

    public static void AddNewProductToBuyer(Product newProduct, User selectedBuyer)
    {
        selectedBuyer.Products.Add(newProduct);
    }

    public static void AddNewUserToList(User newUser, List<User> listBuyers)
    {
        listBuyers.Add(newUser);
    }
}
