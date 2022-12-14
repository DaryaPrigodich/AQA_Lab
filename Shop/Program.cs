using Bogus.DataSets;
using Shop;

class Program
{
    public static void Main(string[] args)
    {
        var rand = new Random();
        var listBuyers = new Factory().GetUsers(rand.Next(1, 5));
        var a = true;
        while (a)
        {
            Console.WriteLine("Введите от 0 до 5, чтобы:");
            Console.WriteLine("0 - посмотреть имена всех покупателей;");
            Console.WriteLine("1 - посмотреть всех покупателей и их корзины;");
            Console.WriteLine("2 - узнать итоговую сумму всех товаров в корзине определенного покупателя;");
            Console.WriteLine("3 - добавить нового покупателя;");
            Console.WriteLine("4 - добавить товар в корзину;");
            Console.WriteLine("5 - удалить товар из корзины;");

            var userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 0:

                    foreach (var buyer in listBuyers)
                    {
                        Console.WriteLine($"{buyer.Name}");
                    }

                    Console.WriteLine("Вернуться в главное меню? Y/N");
                    var choice = Console.ReadLine();
                    if (choice == "Y")
                    {
                        a = true;
                    }
                    else a = false;

                    break;
                case 1:

                    foreach (var buyer in listBuyers)
                    {
                        Console.WriteLine($"{buyer.Name}, {buyer.PassportId}");
                        foreach (var product in buyer.Products)
                        {
                            Console.WriteLine(
                                $"{product.ProductName}, {product.ProductCategory[0]}, {product.ProductPrice}$");
                        }
                    }

                    Console.WriteLine("Вернуться в главное меню? Y/N");
                    var choice1 = Console.ReadLine();
                    if (choice1 == "Y")
                    {
                        a = true;
                    }
                    else a = false;

                    break;
                case 2:
                    Console.WriteLine("Введите имя покупателя:");
                    var nameOfBuyer = Console.ReadLine();

                    var selectedBuyer = listBuyers.First(buyer => buyer.Name == nameOfBuyer);
                    var selectedBuyerCartSum = selectedBuyer.Products.Sum(product => product.ProductPrice);
                    Console.WriteLine(
                        $"Итоговая сумма всех товаров в корзине покупателя:{selectedBuyer.Name} - {selectedBuyerCartSum}$");

                    Console.WriteLine("Вернуться в главное меню? Y/N");
                    var choice2 = Console.ReadLine();
                    if (choice2 == "Y")
                    {
                        a = true;
                    }
                    else a = false;

                    break;
                case 3:
                    Console.WriteLine("Введите имя покупателя:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Введите id покупателя:");
                    var id = Console.ReadLine();
                    Console.WriteLine("Введите возраст покупателя:");
                    var age = int.Parse(Console.ReadLine());

                    var newUser = new User() { PassportId = id, Name = name, Age = age, Products = null };

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

                    Console.WriteLine("Вернуться в главное меню? Y/N");
                    var choice3 = Console.ReadLine();
                    if (choice3 == "Y")
                    {
                        a = true;
                    }
                    else a = false;

                    break;
                case 4:
                    Console.WriteLine("Введите имя пользователя кому хотите добавить товар:");
                    var chosenBuyer = Console.ReadLine();
                    var selectedBuyer2 = listBuyers.First(buyer => buyer.Name == chosenBuyer);
                    if (listBuyers.Any(s => s.Name == chosenBuyer))
                    {
                        Console.WriteLine("Введите id товара:");
                        var productId = Console.ReadLine();
                        Console.WriteLine("Введите имя товара:");
                        var productName = Console.ReadLine();
                        Console.WriteLine("Введите цену товара:");
                        var productPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите описание товара:");
                        string[] productCategory = Console.ReadLine().Split(' ');
                        
                        var newProduct = new Product() { ProductId = productId, ProductName = productName, ProductPrice = productPrice, ProductCategory = productCategory };

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
                    else Console.WriteLine("Покупатель не зарегестрирован!");
                   
                    Console.WriteLine("Вернуться в главное меню? Y/N");
                    var choice4 = Console.ReadLine();
                    if (choice4 == "Y")
                    {
                        a = true;
                    }
                    else a = false;

                    break;
                case 5:
                    Console.WriteLine("Введите имя пользователя у кого хотите удалить товар:");
                    var chosenBuyer2 = Console.ReadLine();
                    var selectedBuyer3 = listBuyers.First(buyer => buyer.Name == chosenBuyer2);
                    if (listBuyers.Any(s => s.Name == chosenBuyer2))
                    {
                        Console.WriteLine("Введите имя товара:");
                        var deletedProductName = Console.ReadLine();
                        //var newProduct = new Product() { ProductId = null, ProductName = deletedProductName, ProductPrice = 0, ProductCategory = null };

                        if (selectedBuyer3.Products.Any(s => s.ProductName == deletedProductName))
                        {
                            selectedBuyer3.Products.RemoveAll(product => product.ProductName == deletedProductName);
                            Console.WriteLine("Товар удален из корзины.");
                        }
                        else
                        {
                            Console.WriteLine("Такого товара нет в корзине.");
                        }

                        Console.WriteLine("Вернуться в главное меню? Y/N");
                        var choice5 = Console.ReadLine();
                        if (choice5 == "Y")
                        {
                            a = true;
                        }
                        else a = false;
                    }
                    break;
            }
        }   
    }
}
