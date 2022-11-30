using Bogus;
using HW2.Entities;

namespace HW2.Factories;

public class UserFactory
{
    public T? GetUser<T>() where T : Worker =>
        typeof(T) == typeof(Employee)
            ? GetEmployees(1).First() as T
            : GetCandidates(1).First() as T;

    public List<Candidate> GetCandidates(int candidatesCount) =>
        GetBasicWorkerFaker<Candidate>().Generate(candidatesCount);

    public List<Employee> GetEmployees(int employeesCount) =>
        GetBasicWorkerFaker<Employee>()
            .RuleFor(u => u.CompanyName, f => f.Company.CompanyName())
            .RuleFor(u => u.CompanyCountry, f => f.Address.Country())
            .RuleFor(u => u.CompanyCity, f => f.Address.City())
            .RuleFor(u => u.CompanyCity, f => f.Address.StreetName())
            .Generate(employeesCount);

    private Faker<T> GetBasicWorkerFaker<T>() where T : Worker =>
        new Faker<T>().RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.JobTittle, f => f.Name.JobTitle())
            .RuleFor(u => u.JobDescriptor, f => f.Name.JobDescriptor())
            .RuleFor(u => u.JobSalary, f => f.Random.Decimal(1000.0M, 3000.0M));
}
