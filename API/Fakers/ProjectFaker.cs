using API.Models;
using Bogus;

namespace API.Fakers;

public class ProjectFaker : Faker<Project>
{
    public ProjectFaker()
    {
        RuleFor(c => c.Name, f => f.Company.CompanyName());
        RuleFor(c => c.Announcement, f => f.Random.Words(3));
        RuleFor(c => c.ShowAnnouncement, f => f.Random.Bool());
        RuleFor(c => c.SuiteMode, f => f.Random.Int(1, 3));
    }
}
