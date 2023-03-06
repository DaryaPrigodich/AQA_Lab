using FluentAssertions;
using NUnit.Framework;
using SpecFlowProject.Pages;

namespace SpecFlowProject.Steps;

[Binding]
public sealed class MilestoneStepDefinition : BaseStepDefinition
{
    private readonly DashboardPage _dashboardPage;
    private readonly AddAndEditMilestonePage _addAndEditMilestonePage;
    private readonly OverviewMilestonePage _overviewMilestonePage;

    public MilestoneStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _dashboardPage = new DashboardPage(Driver);
        _addAndEditMilestonePage = new AddAndEditMilestonePage(Driver);
        _overviewMilestonePage = new OverviewMilestonePage(Driver);
    }

    [When(@"user clicks milestone button on created project with (.*) name")]
    public void WhenUserClicksMilestoneButtonOnCreatedProject(string projectName)
    {
        _dashboardPage.MilestoneButton(projectName).Click();
        
        Assert.That(_overviewMilestonePage.IsPageOpened, "Milestone page wasn't opened.");
    }

    [When(@"user clicks add milestone button")]
    public void WhenUserClicksAddMilestoneButton()
    {
        _overviewMilestonePage.SidebarAddMilestoneButton.Click();
        
        Driver.Title.Should().Match("Add Milestone - TestRail","Add milestone page wasn't opened.");
    }

    [When(@"user enters milestone name - (.*)")]
    public void WhenUserEntersMilestoneName(string milestoneName)
    {
        _addAndEditMilestonePage.NameMilestoneInput.SendKeys(milestoneName);
    }

    [When(@"user submits milestone form")]
    public void WhenUserSubmitsMilestoneForm()
    {
        _addAndEditMilestonePage.AddMilestoneButton.Click();
        
        Assert.That(_overviewMilestonePage.MessageSuccess.Displayed, "Milestone wasn't added or updated.");
    }

    [Then(@"milestone (.*) is added")][Then(@"milestone (.*) is updated")]
    public void ThenMilestoneIsAddedOrUpdated(string milestoneName)
    {
        Assert.That(_overviewMilestonePage.Milestone(milestoneName).Displayed, "Milestone doesn't exist in list.");
    }

    [When(@"user clicks edit milestone button")]
    public void WhenUserClicksEditMilestoneButton()
    {
        _overviewMilestonePage.EditMilestoneButton.Click();

        Driver.Title.Should().Be("Edit Milestone - TestRail", "Edit milestone page wasn't opened.");
    }

    [When(@"user enters updated milestone name - (.*)")]
    public void WhenUserEntersUpdatedMilestoneNameNewMilestone(string updatedName)
    {
        _addAndEditMilestonePage.NameMilestoneInput.Clear();
        _addAndEditMilestonePage.NameMilestoneInput.SendKeys(updatedName);
    }

    [When(@"user clicks delete milestone button")]
    public void WhenUserClicksDeleteMilestoneButton()
    {
        _overviewMilestonePage.DeleteMilestoneButton.Click();
    }

    [When(@"user confirms deletion")]
    public void WhenUserConfirmsDeletion()
    {
        _overviewMilestonePage.ConfirmDeletionButton.Click();
    }

    [Then(@"milestone is deleted from project")]
    public void ThenMilestoneIsDeleted()
    {
        Assert.That(_overviewMilestonePage.MessageSuccess.Displayed, "Milestone wasn't deleted.");
    }

   
}
