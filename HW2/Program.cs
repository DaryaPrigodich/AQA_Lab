using Bogus;
using HW2.Entities;
using HW2.Factories;

namespace HW2;

public class Program
{
    public static void Main(string[] args)
    {
        var faker = new Faker();
        var userFactory = new UserFactory();
        
        var employees = userFactory.GetEmployees(faker.Random.Int(1, 5));
        var candidates = userFactory.GetCandidates(faker.Random.Int(1, 5));
        employees.ForEach(e => { Console.WriteLine($"Employee - {e.FullName}"); });
        candidates.ForEach(c => { Console.WriteLine($"Candidate - {c.FullName}"); });

        IIntroducer? employee = userFactory.GetUser<Employee>();
        IIntroducer? candidate = userFactory.GetUser<Candidate>();
        employee?.PrintPersonInfo();
        candidate?.PrintPersonInfo();
    }
}
