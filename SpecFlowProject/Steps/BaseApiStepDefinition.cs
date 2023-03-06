
using API.Clients;
using SpecFlowProject.Models.Enum;
using SpecFlowProject.Services;

namespace SpecFlowProject.Steps;

[Binding]
public class BaseApiStepDefinition
{
    protected ProjectService? ProjectService;
    protected MilestoneService? MilestoneService;
    
    public BaseApiStepDefinition()
    {
        var restClient = new RestClientExtended(UserType.Admin);
        ProjectService = new ProjectService(restClient);
        MilestoneService = new MilestoneService(restClient);
    }
    
}
