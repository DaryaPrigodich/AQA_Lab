using ConsoleApp1.Models;

namespace HW2.Models;

public class Candidate : Worker, IIntroducable
{
    public void PrintPersonInfo()
    {
        Console.WriteLine($"Hello, I am {FullName} I want to be a {JobTittle}({JobDescriptor}) with a salary" +
                          $" from {JobSalary}");
    }
}