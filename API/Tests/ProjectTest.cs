using System.Net;
using API.Fakers;
using API.Models;
using FluentAssertions;
using NUnit.Framework;

namespace API.Tests;

public class ProjectTest : BaseTest
{
    private Project _project = null!;

    [Test]
    [Order(1)]
    public void AddProjectTest()
    {
        _project = new ProjectFaker().Generate();
        var createdProject = ProjectService.AddProject(_project).Result;
        _project.Name.Should().Be(createdProject.Name);
        _project = createdProject;
    }

    [Test]
    [Order(2)]
    public void GetProjectTest()
    {
        var currentProject = ProjectService.GetProject(_project.Id.ToString()).Result;
        _project.Id.Should().Be(currentProject.Id);
    }

    [Test]
    [Order(3)]
    public void GetProjectsTest()
    {
        var projects = ProjectService.GetProjects().Result;
        projects.ProjectsList.Length.Should().Be(2);
    }
    
    [Test]
    [Order(4)]
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
    public void DeleteProjectsTest()
    {
        var statusCode = ProjectService.DeleteProject(_project.Id.ToString());
        Assert.AreEqual(HttpStatusCode.OK, statusCode);
    }
}
