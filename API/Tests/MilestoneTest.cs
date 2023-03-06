using System.Net;
using Allure.Commons;
using API.Fakers;
using API.Models;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace API.Tests;

[TestFixture]
[AllureNUnit]
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
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Add Milestone")]
    public void AddMilestoneTest()
    {
        _milestone = new MilestoneFaker().Generate();
        var createdMilestone = MilestoneService?.AddMilestone(_project.Id.ToString(), _milestone).Result;
        createdMilestone.Name.Should().Be(_milestone.Name);
        _milestone = createdMilestone;
    }

    [Test]
    [Order(2)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Get Milestone")]
    public void GetMilestoneTest()
    {
        var milestone = MilestoneService.GetMilestone(_milestone.Id.ToString()).Result;
        _milestone.Description.Should().Be(milestone.Description);
    }

    [Test]
    [Order(3)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Get Milestone")]
    public void GetMilestonesTest()
    {
        var milestones = MilestoneService.GetMilestones(_project.Id.ToString()).Result;
        milestones.MilestoneList.Length.Should().Be(1);
    }

    [Test]
    [Order(4)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Update Milestone")]
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
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Delete Milestone")]
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
