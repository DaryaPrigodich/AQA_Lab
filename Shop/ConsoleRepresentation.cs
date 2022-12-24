namespace Shop;

public class ConsoleRepresentation
{
    public static void PrintInformationForSelection()
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

    public static void PrintContinueOrStopProgram()
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
        Console.WriteLine("Вернуться в главное меню? Y/N");
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

    public static void PrintListOfBuyerNames(List<User> listBuyers)
    {
        foreach (var buyer in listBuyers)
        {
            Console.WriteLine($"{buyer.Name}");
        }
    }

    public static void PrintListOfBuyersNamesOrSoppingCarts(List<User> listBuyers, int userChoice)
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
}
