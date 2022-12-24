namespace Shop;

public class ConsoleRepresentation
{
    private static void PrintInformationForSelection()
    {
        Console.WriteLine(
            "Введите число от 0 до 5, чтобы: \n0 - посмотреть имена всех покупателей; \n1 - посмотреть всех покупателей и их корзины; \n2 - узнать итоговую сумму всех товаров в корзине определенного покупателя;  \n3 - добавить нового покупателя; \n4 - добавить товар в корзину; \n5 - удалить товар из корзины;");
    }

    public static void PrintTextForRepeating()
    {
        Console.WriteLine("Попробуйте еще раз.");
    }

    public static void PrintNameOfBuyer()
    {
        Console.WriteLine("Введите имя покупателя:");
    }

    public static void PrintIdOfBuyer()
    {
        Console.WriteLine("Введите id покупателя:");
    }

    public static void PrintAgeOfBuyer()
    {
        Console.WriteLine("Введите возраст покупателя:");
    }

    public static void PrintUnregisteredBuyer()
    {
        Console.WriteLine("Покупатель не зарегестрирован!");
    }

    public static void PrintNameOfProduct()
    {
        Console.WriteLine("Введите имя товара:");
    }

    private static void PrintContinueOrStopProgram()
    {
        Console.WriteLine("Вернуться в главное меню? Y/N");
    }

    public static void PrintSumSoppingCart(User selectedBuyer, decimal selectedBuyerCartSum)
    {
        Console.WriteLine(
            $"Итоговая сумма всех товаров в корзине покупателя:{selectedBuyer.Name} - {selectedBuyerCartSum}$");
    }

    public static void PrintCancelAddingUser()
    {
        Console.WriteLine("Покупатель с таким id уже зарегестрирован. Используйте другой.");
    }

    public static void PrintAddingUser()
    {
        Console.WriteLine("Покупатель добавлен.");
    }

    public static void PrintIdOfProduct()
    {
        Console.WriteLine("Введите id товара:");
    }

    public static void PrintPriceOfProduct()
    {
        Console.WriteLine("Введите цену товара:");
    }

    public static void PrintDescriptionOfProduct()
    {
        Console.WriteLine("Введите описание товара:");
    }

    public static void PrintAgeLimitForAlcohol()
    {
        Console.WriteLine("Алкоголь можно покупать лицам старше 18 лет!");
    }

    public static void PrintProductAddConfirmation()
    {
        Console.WriteLine("Товар добавлен в корзину.");
    }

    public static void PrintProductRemoveConfirmation()
    {
        Console.WriteLine("Товар удален из корзины.");
    }

    public static void PrintProductAbsence()
    {
        Console.WriteLine("Такого товара нет в корзине.");
    }

    private static void PrintListOfBuyersNamesOrSoppingCarts(List<User> listBuyers, int userChoice)
    {
        foreach (var buyer in listBuyers)
        {
            if (userChoice == 0)
            {
                Console.WriteLine($"{buyer.Name}");
            }
            else if (userChoice == 1)
            {
                Console.WriteLine($"{buyer.Name}, {buyer.PassportId}");

                if (buyer.Products == null)
                {
                    Console.WriteLine("Корзина покупателя пуста.");
                }
                else
                    foreach (var product in buyer.Products)
                    {
                        Console.WriteLine(
                            $"{product.ProductName}, {product.ProductCategory[0]}, {product.ProductPrice}$");
                    }
            }
        }
    }

    private static void GetUserChoice(out bool restartLoop)
    {
        PrintContinueOrStopProgram();
        var choice = Console.ReadLine();

        if (choice is "Y" or "y")
        {
            restartLoop = true;
        }
        else restartLoop = false;
    }

    public static bool VerifyNewBuyerById(string idNewUser, List<User> listBuyers)
    {
        var contains = listBuyers.Any(s => s.PassportId == idNewUser);

        if (contains)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool VerifyAgeForAlcohol(string productName, List<User> listBuyers)
    {
        const int ageToBuyAlcohol = 18;

        if (productName == "Alcohol" && listBuyers.Any(s => s.Age < ageToBuyAlcohol))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static void GetSumSoppingCart(List<User> listBuyers)
    { 
        PrintNameOfBuyer();
        var chosenBuyer = Console.ReadLine();

        InstancesHelper.VerifyExistChosenBuyer(listBuyers, chosenBuyer, out var existingBuyer);

        if (string.IsNullOrEmpty(chosenBuyer) || existingBuyer == false)
        {
            PrintTextForRepeating();
        }
        else
        {
            InstancesHelper.CountSumSoppingCart(listBuyers, chosenBuyer);
        }
    }

    public static void Start()
    {
        InstancesHelper.CreateListOfBuyers(out var listBuyers);

        var restartLoop = true;

        while (restartLoop)
        {
            PrintInformationForSelection();

            InstancesHelper.VerifyCorrectUserChoice(out var isUserChoice, out var userChoice);

            if (isUserChoice == false)
            {
               PrintTextForRepeating();
            }
            else
            {
                switch (userChoice)
                {
                    case 0:
                    case 1:
                        PrintListOfBuyersNamesOrSoppingCarts(listBuyers, userChoice);

                        GetUserChoice(out restartLoop);
                        break;
                    case 2:
                        
                        GetSumSoppingCart(listBuyers);

                        GetUserChoice(out restartLoop);
                        break;
                    case 3:
                        InstancesHelper.AddNewUserToList(listBuyers);
                        
                        GetUserChoice(out restartLoop);
                        break;
                    case 4:
                        InstancesHelper.AddCreatedProductToBuyerCart(listBuyers);
                        
                        GetUserChoice(out restartLoop);
                        break;
                    case 5:
                        InstancesHelper.RemoveChosenProductFromBuyerCart(listBuyers);
                        
                        GetUserChoice(out restartLoop);
                        break;
                }
            }
        }
    }
}
