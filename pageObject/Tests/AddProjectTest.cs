using pageObject.BaseEntities;
using pageObject.Enums;
using pageObject.Pages;
using pageObject.Steps;

namespace pageObject;

public class AddProjectTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
        var loginSteps = new LoginSteps(_driver);
        loginSteps.Login();
    }

    [Test]
    [SmokeTest]
    public void AddSingleForAllTypeProjectTest()
    {
        var addProjectsSteps = new AddProjectSteps(_driver);
        addProjectsSteps.AddProject(Project.Name, Project.Announcement, Project.Type = ProjectType.SingleForAll);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(_driver).IsPageOpened());
    }

    [Test]
    [SmokeTest]
    public void AddSingleBaselineTypeProjectTest()
    {
        var addProjectsSteps = new AddProjectSteps(_driver);
        addProjectsSteps.AddProject(Project.Name, Project.Announcement, Project.Type = ProjectType.SingleBaseline);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(_driver).IsPageOpened());
    }

    [Test]
    [SmokeTest]
    public void AddMultipleTypeProjectTest()
    {
        var addProjectsSteps = new AddProjectSteps(_driver);
        addProjectsSteps.AddProject(Project.Name, Project.Announcement, Project.Type = ProjectType.Multiple);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(_driver).IsPageOpened());
    }
}
