namespace ConsoleApp1.Models;

public class Worker : Person
{
    public string JobTittle { get; set; }
    
    public string JobDescriptor { get; set; }
    
    public decimal JobSalary { get; set; }
}