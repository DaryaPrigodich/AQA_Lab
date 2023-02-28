using System.Net;
using API.Fakers;
using API.Models;
using FluentAssertions;

namespace API.Tests;

public class MilestoneTest : BaseTest
{
    private Project _project = null!;
    private Milestone _milestone = null!;

    [OneTimeSetUp]
    public void SetUp()
    {
        _project = new ProjectFaker().Generate();
        var project = ProjectService.AddProject(_project).Result;
        _project = project;
    }

    [Test]
    [Order(1)]
    public void AddMilestoneTest()
    {
        _milestone = new MilestoneFaker().Generate();
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
        var milestone = new MilestoneFaker().Generate();
        milestone.Id = _milestone.Id;
        milestone.IsStarted = true;

        var updatedMilestone = MilestoneService.UpdateMilestone(milestone).Result;
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
