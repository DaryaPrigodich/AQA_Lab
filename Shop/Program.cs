using Shop;
using Random = System.Random;

class Program
{
    public static void Main(string[] args)
    {
        var random = new Random();
        var listBuyers = new Factory(random.Next(3, 5)).GetUsers(random.Next(1, 4));

        string chosenBuyer;
        User selectedBuyer;
        bool restartLoop = true;

        while (restartLoop)
        {
            Console.WriteLine("Введите число от 0 до 5, чтобы:");
            Console.WriteLine("0 - посмотреть имена всех покупателей;");
            Console.WriteLine("1 - посмотреть всех покупателей и их корзины;");
            Console.WriteLine("2 - узнать итоговую сумму всех товаров в корзине определенного покупателя;");
            Console.WriteLine("3 - добавить нового покупателя;");
            Console.WriteLine("4 - добавить товар в корзину;");
            Console.WriteLine("5 - удалить товар из корзины;");

            int userChoice;
            var isUserChoise = int.TryParse(Console.ReadLine(), out userChoice) && userChoice >= 0 && userChoice <= 5;

            if (isUserChoise == false)
            {
                Console.WriteLine("Попробуйте еще раз.");
            }
            else
            {
                switch (userChoice)
                {
                    case 0:
                        ListOfBuyerNames(listBuyers);

                        UserChoice(out restartLoop);
                        break;
                    case 1:
                        ShoppingCarts(listBuyers);

                        UserChoice(out restartLoop);
                        break;
                    case 2:
                        Console.WriteLine("Введите имя покупателя:");
                        var nameOfBuyer = Console.ReadLine();

                        if (string.IsNullOrEmpty(nameOfBuyer)) Console.WriteLine("Попробуйте еще раз.");
                        else SummSoppingCart(nameOfBuyer, listBuyers);

                        UserChoice(out restartLoop);
                        break;
                    case 3:
                        Console.WriteLine("Введите имя покупателя:");
                        var nameNewUser = Console.ReadLine();

                        Console.WriteLine("Введите id покупателя:");
                        var idNewUser = Console.ReadLine();

                        Console.WriteLine("Введите возраст покупателя:");
                        int ageNewUser;
                        var isAge = int.TryParse(Console.ReadLine(), out ageNewUser) && ageNewUser > 7 &&
                                    ageNewUser < 100;

                        if (string.IsNullOrEmpty(nameNewUser) || string.IsNullOrEmpty(idNewUser) || isAge == false)
                        {
                            Console.WriteLine("Заполните поля корректными данными. Попробуйте еще раз.");
                        }
                        else
                        {
                            var newUser = new User()
                                { PassportId = idNewUser, Name = nameNewUser, Age = ageNewUser, Products = null };

                            VarifyNewBuyerById(idNewUser, newUser, listBuyers);
                        }

                        UserChoice(out restartLoop);
                        break;
                    case 4:
                        Console.WriteLine("Введите имя пользователя кому хотите добавить товар:");
                        chosenBuyer = Console.ReadLine();

                        if (string.IsNullOrEmpty(chosenBuyer))
                        {
                            Console.WriteLine("Попробуйте еще раз.");
                        }
                        else if (listBuyers.Any(s => s.Name == chosenBuyer))
                        {
                            selectedBuyer = listBuyers.First(buyer => buyer.Name == chosenBuyer);

                            string productName;
                            Product newProduct;
                            AddNewProduct(out productName, out newProduct);

                            VarifyAgeForAlcohol(productName, newProduct, selectedBuyer, listBuyers);
                        }
                        else Console.WriteLine("Покупатель не зарегестрирован!");

                        UserChoice(out restartLoop);
                        break;
                    case 5:
                        Console.WriteLine("Введите имя пользователя у кого хотите удалить товар:");
                        chosenBuyer = Console.ReadLine();

                        if (string.IsNullOrEmpty(chosenBuyer))
                        {
                            Console.WriteLine("Попробуйте еще раз.");
                        }
                        else if (listBuyers.Any(s => s.Name == chosenBuyer))
                        {
                            selectedBuyer = listBuyers.First(buyer => buyer.Name == chosenBuyer);

                            Console.WriteLine("Введите имя товара:");
                            var deletedProductName = Console.ReadLine();

                            RemoveProductByName(selectedBuyer, deletedProductName);
                        }
                        else Console.WriteLine("Покупатель не зарегестрирован!");

                        UserChoice(out restartLoop);
                        break;
                }
            }
        }
    }

    static void UserChoice(out bool restartLoop)
    {
        Console.WriteLine("Вернуться в главное меню? Y/N");
        var choice = Console.ReadLine();
       
        if (choice == "Y")
        {
            restartLoop = true;
        }
        else restartLoop = false;
    }

    static void ListOfBuyerNames(List<User> listBuyers)
    {
        foreach (var buyer in listBuyers)
        {
            Console.WriteLine($"{buyer.Name}");
        }
    }

    static void ShoppingCarts(List<User> listBuyers)
    {
        foreach (var buyer in listBuyers)
        {
            Console.WriteLine($"{buyer.Name}, {buyer.PassportId}");
            foreach (var product in buyer.Products)
            {
                Console.WriteLine(
                    $"{product.ProductName}, {product.ProductCategory[0]}, {product.ProductPrice}$");
            }
        }
    }

    static void SummSoppingCart(string nameOfBuyer, List<User> listBuyers)
    {
        var selectedBuyer = listBuyers.First(buyer => buyer.Name == nameOfBuyer);
        var selectedBuyerCartSum = selectedBuyer.Products.Sum(product => product.ProductPrice);
        Console.WriteLine(
            $"Итоговая сумма всех товаров в корзине покупателя:{selectedBuyer.Name} - {selectedBuyerCartSum}$");
    }

    static void VarifyNewBuyerById(string id, User newUser, List<User> listBuyers)
    {
        bool contains = listBuyers.Any(s => s.PassportId == id);

        if (contains)
        {
            Console.WriteLine("Пользователь с таким Id уже существует!");
        }
        else
        {
            listBuyers.Add(newUser);
            Console.WriteLine("Покупатель добавлен.");
        }
    }

    static void AddNewProduct(out string productName, out Product newProduct)
    {
        Console.WriteLine("Введите id товара:");
        var productId = Console.ReadLine();
        
        Console.WriteLine("Введите имя товара:");
        productName = Console.ReadLine();
        
        Console.WriteLine("Введите цену товара:");
        var productPrice = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите описание товара:");
        var productCategory = Console.ReadLine();

        newProduct = new Product()
        {
            ProductId = productId, ProductName = productName, ProductPrice = productPrice,
            ProductCategory = productCategory
        };
    }

    static void VarifyAgeForAlcohol(string productName, Product newProduct, User selectedBuyer2, List<User> listBuyers)
    {
        if (productName == "Alcohol" && listBuyers.Any(s => s.Age < 18))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Алкоголь можно покупать лицам старше 18 лет!");
            Console.ResetColor();
        }
        else
        {
            selectedBuyer2.Products.Add(newProduct);
            Console.WriteLine("Товар добавлен в корзину.");
        }
    }

    static void RemoveProductByName(User selectedBuyer3, string deletedProductName)
    {
        if (selectedBuyer3.Products.Any(s => s.ProductName == deletedProductName))
        {
            selectedBuyer3.Products.RemoveAll(product => product.ProductName == deletedProductName);
            Console.WriteLine("Товар удален из корзины.");
        }
        else
        {
            Console.WriteLine("Такого товара нет в корзине.");
        }
    }
}
