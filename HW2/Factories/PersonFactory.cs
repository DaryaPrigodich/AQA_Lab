using Bogus;
using ConsoleApp1.Models;
using HW2.Models;

namespace HW2.Factories;

public class PersonFactory
{
    public List<Employee> GetEmployees(int employeeCount)
    {
        return new Faker<Employee>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.JobTittle, f => f.Name.JobTitle())
            .RuleFor(u => u.JobDescriptor, f => f.Name.JobDescriptor())
            .RuleFor(u => u.JobSalary, f => f.Random.Decimal(1000.0M, 3000.0M))
            .RuleFor(u => u.CompanyName, f => f.Company.CompanyName())
            .RuleFor(u => u.CompanyCountry, f => f.Address.Country())
            .RuleFor(u => u.CompanyCity, f => f.Address.City())
            .RuleFor(u => u.CompanyCity, f => f.Address.StreetName())
            .Generate(employeeCount);
    }

    public List<Candidate> GetCandidates(int candidateCount)
    {
        return new Faker<Candidate>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.JobTittle, f => f.Name.JobTitle())
            .RuleFor(u => u.JobDescriptor, f => f.Name.JobDescriptor())
            .RuleFor(u => u.JobSalary, f => f.Random.Decimal(1000.0M, 3000.0M))
            .Generate(candidateCount);
    }
}
