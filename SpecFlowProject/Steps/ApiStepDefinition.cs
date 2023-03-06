using System.Net;
using FluentAssertions;
using NUnit.Framework;
using SpecFlowProject.Models;

namespace SpecFlowProject.Steps;

[Binding]
public sealed class ApiStepDefinition : BaseApiStepDefinition
{
    private Project _project = null!;
    private Milestone _milestone = null!;

    [Given(@"new project with (.*) name has been created via API")]
    public void GivenNewProjectWithNameHasBeenCreatedViaApi(string projectName)
    {
        _project = new Project
        {
            Name = projectName,
            SuiteMode = 2
        };
        var project = ProjectService.AddProject(_project).Result;
        _project = project;
    }

    [When(@"user adds milestone (.*) name into last created project")]
    public void WhenUserAddsMilestoneApiMilestoneNameIntoLastCreatedProject(string milestoneName)
    {
        _milestone = new Milestone
        {
            Name = milestoneName
        };
        var createdMilestone = MilestoneService?.AddMilestone(_project.Id.ToString(), _milestone).Result;
        createdMilestone.Name.Should().Be(_milestone.Name);
        _milestone = createdMilestone;
    }

    [Then(@"milestone is added")]
    [Then(@"milestone is updated")]
    public void ThenMilestoneIsAddedOrUpdated()
    {
        var actualMilestone = MilestoneService.GetMilestone(_milestone.Id.ToString()).Result;
        _milestone.Name.Should().Be(actualMilestone.Name);
        _milestone = actualMilestone;
    }

    [When(@"user updates last created milestone name to (.*) name")]
    public void WhenUserUpdatesLastCreatedMilestoneNameToName(string updatedMilestoneName)
    {
        var milestoneToAdd = new Milestone
        {
            Id = _milestone.Id,
            Name = updatedMilestoneName,
            IsCompleted = false,
            IsStarted = true
        };
        var updatedMilestone = MilestoneService?.UpdateMilestone(milestoneToAdd).Result;

        updatedMilestone.IsStarted.Should().BeTrue();

        _milestone = updatedMilestone;
    }

    [When(@"user deletes last updated milestone")]
    public void WhenUserDeletesLastUpdatedMilestone()
    {
        var statusCode = MilestoneService.DeleteMilestone(_milestone.Id.ToString());

        Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Then(@"milestone is deleted")]
    public void ThenMilestoneIsDeleted()
    {
        var actualMilestone = MilestoneService.GetMilestone(_milestone.Id.ToString()).Result;
        
        actualMilestone.Id.Should().Be(0);
    }

    [Then(@"project is deleted")]
    public void ThenProjectIsDeleted()
    {
        var statusCode = ProjectService.DeleteProject(_project.Id.ToString());
        
        Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
