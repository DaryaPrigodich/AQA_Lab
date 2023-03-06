using System.Net;
using Database.Models;
using Database.Services;
using FluentAssertions;
using NUnit.Framework;

namespace Database.Tests;

public class MilestoneTest : BaseTest
{
    private Project? _project;
    private Milestone? _milestone;

    [OneTimeSetUp]
    public void AddProject()
    {
        var sqlProjectService = new SqlProjectService();
        _project = sqlProjectService.GetProjectBySuiteMode(2);
        
        var project = ProjectService.AddProject(_project).Result;
        _project = project;
    }

    [Test]
    [Order(1)]
    public void AddMilestoneTest()
    {
        var sqlMilestoneService = new SqlMilestoneService();
        _milestone = sqlMilestoneService.GetMilestoneById(1);
        
        var createdMilestone = MilestoneService?.AddMilestone(_project.Id.ToString(), _milestone).Result;
        createdMilestone.Name.Should().Be(_milestone.Name);
        _milestone = createdMilestone;
    }

    [Test]
    [Order(2)]
    public void GetMilestoneTest()
    {
        var milestone = MilestoneService.GetMilestone(_milestone.Id.ToString()).Result;
        _milestone.Description.Should().Be(milestone.Description);
    }
    
    [Test]
    [Order(3)]
    public void GetMilestonesTest()
    {
        var milestones = MilestoneService.GetMilestones(_project.Id.ToString()).Result;
        milestones.MilestoneList.Length.Should().Be(1);
    }

    [Test]
    [Order(4)]
    public void UpdateMilestoneTest()
    {
        var sqlMilestoneService = new SqlMilestoneService();
        var milestoneToAdd = sqlMilestoneService.GetMilestoneById(2);
        milestoneToAdd.Id = _milestone.Id;
        
        var updatedMilestone = MilestoneService?.UpdateMilestone(milestoneToAdd).Result;
        updatedMilestone.IsStarted.Should().BeTrue();
        _milestone = updatedMilestone;
    }

    [Test]
    [Order(5)]
    public void DeleteMilestoneTest()
    {
        var statusCode = MilestoneService.DeleteMilestone(_milestone.Id.ToString());
        Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [OneTimeTearDown]
    public void Delete_Project()
    {
        ProjectService.DeleteProject(_project.Id.ToString());
    }
}
