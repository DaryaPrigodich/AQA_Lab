using Shop;

class Program
{
    public static void Main(string[] args)
    {
        InstancesHelper.CreateListOfBuyers(out var listBuyers);

        string chosenBuyer;
        User selectedBuyer;
        var restartLoop = true;

        while (restartLoop)
        {
            ConsoleRepresentation.PrintInformationForSelection();

            InstancesHelper.VerifyCorrectUserChoice(out var isUserChoice, out var userChoice);

            if (isUserChoice == false)
            {
                ConsoleRepresentation.PrintTextForRepeating();
            }
            else
            {
                switch (userChoice)
                {
                    case 0:
                    case 1:
                        ConsoleRepresentation.PrintListOfBuyersNamesOrSoppingCarts(listBuyers, userChoice);

                        GetUserChoice(out restartLoop);
                        break;
                    case 2:
                        ConsoleRepresentation.PrintNameOfBuyer();
                        chosenBuyer = Console.ReadLine();

                        InstancesHelper.VerifyExistChosenUser(listBuyers, chosenBuyer, out var existingBuyer);

                        if (string.IsNullOrEmpty(chosenBuyer) || existingBuyer == false)
                            ConsoleRepresentation.PrintTextForRepeating();
                        else GetSumSoppingCart(listBuyers, chosenBuyer);

                        GetUserChoice(out restartLoop);
                        break;
                    case 3:
                        ConsoleRepresentation.PrintNameOfBuyer();
                        var nameNewUser = Console.ReadLine();

                        ConsoleRepresentation.PrintIdOfBuyer();
                        var idNewUser = Console.ReadLine();

                        ConsoleRepresentation.PrintAgeOfBuyer();
                       
                        InstancesHelper.VerifyCorrectNewBuyerAge(out var isAge, out var ageNewUser);

                        if (string.IsNullOrEmpty(nameNewUser) || string.IsNullOrEmpty(idNewUser) || isAge == false)
                        {
                            ConsoleRepresentation.PrintTextForRepeating();
                        }
                        else
                        {
                            InstancesHelper.CreateNewUser(out var newUser, idNewUser, nameNewUser, ageNewUser);

                            if (VerifyNewBuyerById(idNewUser, newUser, listBuyers))
                            {
                                InstancesHelper.AddNewUserToList(newUser, listBuyers);
                                
                                ConsoleRepresentation.PrintAddingUser();
                            }
                            else
                            {
                                ConsoleRepresentation.PrintCancelAddingUser();
                            }
                        }

                        GetUserChoice(out restartLoop);
                        break;
                    case 4:
                        ConsoleRepresentation.PrintNameOfBuyer();
                        chosenBuyer = Console.ReadLine();

                        if (string.IsNullOrEmpty(chosenBuyer))
                        {
                            ConsoleRepresentation.PrintTextForRepeating();
                        }
                        else if (listBuyers.Any(s => s.Name == chosenBuyer))
                        {
                            InstancesHelper.GetFirstMatchingBuyerByName(listBuyers, chosenBuyer, out selectedBuyer);

                            AddNewProduct(out var productName, out var newProduct);

                            if (VerifyAgeForAlcohol(productName, listBuyers))
                            {
                                InstancesHelper.AddNewProductToBuyer(newProduct, selectedBuyer);

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

                        GetUserChoice(out restartLoop);
                        break;
                    case 5:
                        ConsoleRepresentation.PrintNameOfBuyer();
                        chosenBuyer = Console.ReadLine();

                        if (string.IsNullOrEmpty(chosenBuyer))
                        {
                            ConsoleRepresentation.PrintTextForRepeating();
                        }
                        else if (listBuyers.Any(s => s.Name == chosenBuyer))
                        {
                            InstancesHelper.GetFirstMatchingBuyerByName(listBuyers, chosenBuyer, out selectedBuyer);

                            ConsoleRepresentation.PrintNameOfProduct();
                            var deletedProductName = Console.ReadLine();

                            RemoveProductByName(selectedBuyer, deletedProductName);
                        }
                        else ConsoleRepresentation.PrintUnregisteredBuyer();

                        GetUserChoice(out restartLoop);
                        break;
                }
            }
        }
    }

    static void GetUserChoice(out bool restartLoop)
    {
        ConsoleRepresentation.PrintContinueOrStopProgram();
        var choice = Console.ReadLine();

        if (choice == "Y" || choice == "y")
        {
            restartLoop = true;
        }
        else restartLoop = false;
    }

    static void GetSumSoppingCart(List<User> listBuyers, string chosenBuyer)
    {
        InstancesHelper.GetFirstMatchingBuyerByName(listBuyers, chosenBuyer, out var selectedBuyer);

        InstancesHelper.GetSumOfBuyerCart(selectedBuyer, out var selectedBuyerCartSum);

        ConsoleRepresentation.PrintSumSoppingCart(selectedBuyer, selectedBuyerCartSum);
    }

    static bool VerifyNewBuyerById(string id, User newUser, List<User> listBuyers)
    {
        var contains = listBuyers.Any(s => s.PassportId == id);

        if (contains)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void AddNewProduct(out string productName, out Product newProduct)
    {
        ConsoleRepresentation.PrintNameOfProduct();
        productName = Console.ReadLine();

        ConsoleRepresentation.PrintIdOfProduct();
        var productId = Console.ReadLine();

        ConsoleRepresentation.PrintPriceOfProduct();
        var productPrice = int.Parse(Console.ReadLine());

        ConsoleRepresentation.PrintDescriptionOfProduct();
        var productCategory = Console.ReadLine();

        InstancesHelper.CreateNewProduct(out newProduct, productId, productName, productPrice, productCategory);
    }

    static bool VerifyAgeForAlcohol(string productName, List<User> listBuyers)
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

    static void RemoveProductByName(User selectedBuyer, string deletedProductName)
    {
        if (selectedBuyer.Products.Any(s => s.ProductName == deletedProductName))
        {
            InstancesHelper.RemoveProductFromBuyerCart(selectedBuyer, deletedProductName);

            ConsoleRepresentation.PrintProductRemoveConfirmation();
        }
        else
        {
            ConsoleRepresentation.PrintProductAbsence();
        }
    }
}
