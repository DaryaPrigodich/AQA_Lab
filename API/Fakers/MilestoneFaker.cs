using API.Models;
using Bogus;

namespace API.Fakers;

public class MilestoneFaker : Faker<Milestone>
{
    public MilestoneFaker()
    {
        RuleFor(m => m.Name, f => f.Company.CompanyName());
        RuleFor(m => m.Description, f => f.Company.CatchPhrase());
    }
}
