namespace HW2.Entities;

public class Employee : Worker, IIntroducer
{
    public string CompanyName { get; set; } = null!;

    public string CompanyCountry { get; set; } = null!;

    public string CompanyCity { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public void PrintPersonInfo()
    {
        Console.WriteLine(
            $"Hello, I am {FullName}, {JobTittle} in {CompanyName}({CompanyCountry}), " + 
                $"{CompanyCity}, {CompanyAddress} and my salary is {JobSalary:F}$");
    }
}
