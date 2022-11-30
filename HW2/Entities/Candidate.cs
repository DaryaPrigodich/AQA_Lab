namespace HW2.Entities;

public class Candidate : Worker, IIntroducer
{
    public void PrintPersonInfo()
    {
        Console.WriteLine(
            $"Hello, I am {FullName} I want to be a {JobTittle}({JobDescriptor}) with a salary" + 
                $" from {JobSalary:F}$");
    }
}
