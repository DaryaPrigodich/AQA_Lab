using API.Clients;
using API.Models.Enum;
using API.Services;
using NUnit.Framework;

namespace API.Tests;

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
