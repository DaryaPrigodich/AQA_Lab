using HW2.Models;

namespace ConsoleApp1.Models;

public class Employee : Worker, IIntroducable
{
    public string CompanyName { get; set; }
    
    public string CompanyCountry { get; set; }

    public string CompanyCity { get; set; }

    public string CompanyStreet { get; set; }
   
    public void PrintPersonInfo()
    {
        Console.WriteLine($"Hello, I am {FullName}, {JobTittle} in {CompanyName}({CompanyCountry}), " +
                          $"{CompanyCity}, {CompanyStreet} and my salary {JobSalary}");
    }
}