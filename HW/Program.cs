//Конвертер USD  / EUR / ZL 
//Конвертер должен уметь получать кол-во денег, конвертируемую валюту и потом валюту, в  которую происходит конвертация
//В итоге пользователь должен получить выведенную на консоль сумму в валюте, которая была указана второй 


Console.WriteLine("Введите сумму обмена:");
float sum = Convert.ToSingle(Console.ReadLine());

Console.WriteLine("Введите валюту 1:");
// старайся использовать более понятные названия переменных, например val1 -> userCurrency, val2 -> exchangeCurrency
string val1 = Console.ReadLine();

Console.WriteLine("Введите валюту 2:");
string val2 = Console.ReadLine();

if (val1 == "USD" && val2 == "EUR") // старайся не хардкодить строки, используй переменные: var usdCurrency = "USD" ...
{
    float a = sum * 0.96f; // запрети себе называть перменную a, b, c ... , имя переменной должно говорить о ее применении
    Console.WriteLine($"{a} EUR");
}
else if (val1 == "USD" && val2 == "ZL") 
{
    float a = sum * 4.88f;
    Console.WriteLine($"{a} ZL");
}
else if (val1 == "EUR" && val2 == "USD") 
{
    float a = sum * 1.04f;
    Console.WriteLine($"{a} USD");
}
else if (val1 == "EUR" && val2 == "ZL") 
{
    float a = sum * 4.68f;
    Console.WriteLine($"{a} ZL");
}
else if (val1 == "ZL" && val2 == "USD")
{
    float a = sum * 0.22f;
    Console.WriteLine($"{a} USD");
}
else 
{
    float a = sum * 0.21f;
    Console.WriteLine($"{a} EUR");
}



