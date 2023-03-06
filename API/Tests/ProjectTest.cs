using System.Net;
using Allure.Commons;
using API.Fakers;
using API.Models;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace API.Tests;

public class ProjectTest : BaseTest
{
    private Project _project = null!;

    [Test]
    [Order(1)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Add Project")]
    public void AddProjectTest()
    {
        _project = new ProjectFaker().Generate();
        var createdProject = ProjectService.AddProject(_project).Result;
        _project.Name.Should().Be(createdProject.Name);
        _project = createdProject;
    }

    [Test]
    [Order(2)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Get Project")]
    public void GetProjectTest()
    {
        var currentProject = ProjectService.GetProject(_project.Id.ToString()).Result;
        _project.Id.Should().Be(currentProject.Id);
    }

    [Test]
    [Order(3)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Get Projects")]
    public void GetProjectsTest()
    {
        var projects = ProjectService.GetProjects().Result;
        projects.ProjectsList.Length.Should().Be(2);
    }
    
    [Test]
    [Order(4)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Update Project")]
    public void UpdateProjectsTest()
    {
        var project = new ProjectFaker().Generate();
        project.Id = _project.Id;
        project.Name = "TestProject Updated";
        
        var updatedProject = ProjectService.UpdateProject(project).Result;
        updatedProject.Name.Should().Match("TestProject Updated");
        _project = updatedProject;
    }

    [Test]
    [Order(5)]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Delete Project")]
    public void DeleteProjectsTest()
    {
        var statusCode = ProjectService.DeleteProject(_project.Id.ToString());
        Assert.AreEqual(HttpStatusCode.OK, statusCode);
    }
}
