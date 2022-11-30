namespace HW2.Entities;

public class Worker : Person
{
    public string JobTittle { get; set; } = null!;

    public string JobDescriptor { get; set; } = null!;

    public decimal JobSalary { get; set; }
}
