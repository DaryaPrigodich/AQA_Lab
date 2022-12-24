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
    
    public static void VerifyExistChosenBuyer(List<User> listBuyers, string nameOfBuyer, out bool existingBuyer)
    {
        existingBuyer = listBuyers.Exists(buyer => buyer.Name == nameOfBuyer);
    }

    private static void VerifyCorrectNewBuyerAge(out bool isAge, out int ageNewUser)
    {
        var writtenUserAge = Console.ReadLine();
        isAge = int.TryParse(writtenUserAge, out ageNewUser) && ageNewUser is > MinUserAge and < MaxUserAge;
    }

    private static void GetFirstMatchingBuyerByName(List<User> listBuyers, string chosenBuyer, out User selectedBuyer)
    {
        selectedBuyer = listBuyers.First(buyer => buyer.Name == chosenBuyer);
    }

    private static void GetSumOfBuyerCart(User selectedBuyer, out decimal selectedBuyerCartSum)
    {
        selectedBuyerCartSum = selectedBuyer.Products.Sum(product => product.ProductPrice);
    }

    private static void CreateNewProduct(out Product newProduct, string productId, string productName, decimal productPrice, string productCategory)
    {
        newProduct = new Product()
        {
            ProductId = productId, ProductName = productName, ProductPrice = productPrice,
            ProductCategory = productCategory
        };
    }

    private static void CreateNewUser(out User newUser, string idNewUser, string nameNewUser,int ageNewUser)
    {
        newUser = new User()
            { PassportId = idNewUser, Name = nameNewUser, Age = ageNewUser, Products = null };
    }

    private static void RemoveProductFromBuyerCart(User selectedBuyer, string deletedProductName)
    {
        selectedBuyer.Products.RemoveAll(product => product.ProductName == deletedProductName);
    }

    private static void AddNewProductToBuyer(Product newProduct, User selectedBuyer)
    {
        selectedBuyer.Products.Add(newProduct);
    }

    private static void AddNewUser(User newUser, List<User> listBuyers)
    {
        listBuyers.Add(newUser);
    }

    private static void AddNewProduct(out string productName, out Product newProduct)
    {
        ConsoleRepresentation.PrintNameOfProduct();
        productName = Console.ReadLine();

        ConsoleRepresentation.PrintIdOfProduct();
        var productId = Console.ReadLine();

        ConsoleRepresentation.PrintPriceOfProduct();
        var productPrice = int.Parse(Console.ReadLine());

        ConsoleRepresentation.PrintDescriptionOfProduct();
        var productCategory = Console.ReadLine();

        CreateNewProduct(out newProduct, productId, productName, productPrice, productCategory);
    }

    private static void RemoveProductByName(User selectedBuyer, string deletedProductName)
    {
        if (selectedBuyer.Products.Any(s => s.ProductName == deletedProductName))
        {
            RemoveProductFromBuyerCart(selectedBuyer, deletedProductName);

            ConsoleRepresentation.PrintProductRemoveConfirmation();
        }
        else
        {
            ConsoleRepresentation.PrintProductAbsence();
        }
    }
    
    public static void CountSumSoppingCart(List<User> listBuyers, string chosenBuyer)
    {
        GetFirstMatchingBuyerByName(listBuyers, chosenBuyer, out var selectedBuyer);
        
        GetSumOfBuyerCart(selectedBuyer, out var selectedBuyerCartSum);
        
        ConsoleRepresentation.PrintSumSoppingCart(selectedBuyer, selectedBuyerCartSum);
    }
    
    public static void AddNewUserToList(List<User> listBuyers)
    {
        ConsoleRepresentation.PrintNameOfBuyer();
        var nameNewUser = Console.ReadLine();

        ConsoleRepresentation.PrintIdOfBuyer();
        var idNewUser = Console.ReadLine();

        ConsoleRepresentation.PrintAgeOfBuyer();
                       
        VerifyCorrectNewBuyerAge(out var isAge, out var ageNewUser);

        if (string.IsNullOrEmpty(nameNewUser) || string.IsNullOrEmpty(idNewUser) || isAge == false)
        {
            ConsoleRepresentation.PrintTextForRepeating();
        }
        else
        {
            CreateNewUser(out var newUser, idNewUser, nameNewUser, ageNewUser);

            if (ConsoleRepresentation.VerifyNewBuyerById(idNewUser, listBuyers))
            {
                ConsoleRepresentation.PrintCancelAddingUser();
            }
            else
            {
                AddNewUser(newUser, listBuyers);

                ConsoleRepresentation.PrintAddingUser();
            }
        }
    }

    public static void AddCreatedProductToBuyerCart(List<User> listBuyers)
    {
        ConsoleRepresentation.PrintNameOfBuyer();
        var chosenBuyer = Console.ReadLine();

        if (string.IsNullOrEmpty(chosenBuyer))
        {
            ConsoleRepresentation.PrintTextForRepeating();
        }
        else if (listBuyers.Any(s => s.Name == chosenBuyer))
        {
            GetFirstMatchingBuyerByName(listBuyers, chosenBuyer, out var selectedBuyer);

            AddNewProduct(out var productName, out var newProduct);

            if (ConsoleRepresentation.VerifyAgeForAlcohol(productName, listBuyers))
            {
                AddNewProductToBuyer(newProduct, selectedBuyer);

                ConsoleRepresentation.PrintProductAddConfirmation();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                ConsoleRepresentation.PrintAgeLimitForAlcohol();

                Console.ResetColor();
            }
        }
        else ConsoleRepresentation.PrintUnregisteredBuyer();
    }

    public static void RemoveChosenProductFromBuyerCart(List<User> listBuyers)
    {
        ConsoleRepresentation.PrintNameOfBuyer();
        var chosenBuyer = Console.ReadLine();

        if (string.IsNullOrEmpty(chosenBuyer))
        {
            ConsoleRepresentation.PrintTextForRepeating();
        }
        else if (listBuyers.Any(s => s.Name == chosenBuyer))
        {
            GetFirstMatchingBuyerByName(listBuyers, chosenBuyer, out var selectedBuyer);

            ConsoleRepresentation.PrintNameOfProduct();
            var deletedProductName = Console.ReadLine();

            RemoveProductByName(selectedBuyer, deletedProductName);
        }
        else ConsoleRepresentation.PrintUnregisteredBuyer();
    }
}
