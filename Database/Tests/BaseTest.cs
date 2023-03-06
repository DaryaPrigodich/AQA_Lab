using Database.Clients;
using Database.Models.Enum;
using Database.Services;
using NUnit.Framework;

namespace Database.Tests;

public class BaseTest
{
    protected ProjectService? ProjectService;
    protected MilestoneService? MilestoneService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended(UserType.Admin);
        ProjectService = new ProjectService(restClient);
        MilestoneService = new MilestoneService(restClient);
    }
}
