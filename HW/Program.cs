//Конвертер USD  / EUR / ZL 
//Конвертер должен уметь получать кол-во денег, конвертируемую валюту и потом валюту, в  которую происходит конвертация
//В итоге пользователь должен получить выведенную на консоль сумму в валюте, которая была указана второй 


Console.WriteLine("Введите сумму обмена:");
float sum = Convert.ToSingle(Console.ReadLine());

Console.WriteLine("Введите валюту 1:");
string userCurrency = Console.ReadLine();

Console.WriteLine("Введите валюту 2:");
string exchangeCurrency = Console.ReadLine();

var usdCurrency = "USD";
var eurCurrecny = "EUR";
var zlCurrency = "ZL";

if (userCurrency == usdCurrency && exchangeCurrency == eurCurrecny) 
{
    float sumExchange = sum * 0.96f;
    Console.WriteLine($"{sumExchange} EUR");
}
else if (userCurrency == usdCurrency && exchangeCurrency == zlCurrency) 
{
    float sumExchange = sum * 4.88f;
    Console.WriteLine($"{sumExchange} ZL");
}
else if (userCurrency == eurCurrecny && exchangeCurrency == usdCurrency) 
{
    float sumExchange = sum * 1.04f;
    Console.WriteLine($"{sumExchange} USD");
}
else if (userCurrency == eurCurrecny && exchangeCurrency == zlCurrency) 
{
    float sumExchange = sum * 4.68f;
    Console.WriteLine($"{sumExchange} ZL");
}
else if (userCurrency == zlCurrency && exchangeCurrency == usdCurrency)
{
    float sumExchange = sum * 0.22f;
    Console.WriteLine($"{sumExchange} USD");
}
else 
{
    float sumExchange = sum * 0.21f;
    Console.WriteLine($"{sumExchange} EUR");
}