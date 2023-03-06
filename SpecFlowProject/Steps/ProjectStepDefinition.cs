using FluentAssertions;
using NUnit.Framework;
using SpecFlowProject.Pages;

namespace SpecFlowProject.Steps;

[Binding]
public class ProjectStepDefinition : BaseStepDefinition
{
    private readonly DashboardPage _dashboardPage;
    private readonly AddProjectPage _addProjectPage;
    private readonly OverviewProjectPage _overviewProjectPage;
    private readonly OverviewMilestonePage _overviewMilestonePage;
    private readonly AdminOverviewPage _adminOverviewPage;
    
    public ProjectStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _dashboardPage = new DashboardPage(Driver);
        _addProjectPage = new AddProjectPage(Driver);
        _overviewProjectPage = new OverviewProjectPage(Driver);
        _overviewMilestonePage = new OverviewMilestonePage(Driver);
        _adminOverviewPage = new AdminOverviewPage(Driver);
    }

    private void ClickAddProjectButton()
    {
        _dashboardPage.SidebarProjectsAddButton.Click();
    }

    private void CreateNewProject(string projectName)
    {
        _addProjectPage.NameProjectInput.SendKeys(projectName);
        _addProjectPage.AnnouncementInput.SendKeys("Announcement");
        _addProjectPage.ShowAnnouncementCheckBox.Click();
        _addProjectPage.RadioModes[2].Click(); 
        _addProjectPage.AddProjectButton.Click();
    }

    [Given(@"new project with (.*) name has been created")]
    public void GivenNewProjectHasBeenCreated(string projectName)
    {
        ClickAddProjectButton();
        
        Driver.Title.Should().Match("Add Project - TestRail","AddProject page wasn't opened.");

        CreateNewProject(projectName);
        
        Assert.That(_overviewProjectPage.MessageSuccess.Displayed, "New project wasn't added.");
    }


    [Given(@"dashboard page with created project has been opened")]
    public void GivenDashboardPageWithCreatedProjectHasBeenOpened()
    {
        _overviewProjectPage.DashboardButton.Click();
       
        Assert.That(_dashboardPage.IsPageOpened, "Dashboard page wasn't opened.");
    }

    [Then(@"project with (.*) name is deleted")]
    public void ThenProjectWithTestProjectNameIsDeleted(string projectName)
    {
        _overviewMilestonePage.AdministrationButton.Click();
        
        Driver.Title.Should().Match("Overview - TestRail","Admin overview page wasn't opened.");
        
        _adminOverviewPage.NavigationProjectsButton.Click();
        
        Assert.That(_overviewProjectPage.IsPageOpened(), "Project overview page wasn't opened.");
        
        _overviewProjectPage.DeleteProjectButton(projectName).Click();
        _overviewProjectPage.ConfirmationDeleteProjectCheckBox.Click();
        _overviewProjectPage.ConfirmationDeleteProjectButton.Click();
        
        Assert.That(_overviewProjectPage.MessageSuccess.Displayed, "Project wasn't deleted.");
    }
}
