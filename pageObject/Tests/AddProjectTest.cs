using pageObject.BaseEntities;
using pageObject.Pages;

namespace pageObject;

public class AddProjectTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
        var loginPage = new LoginPage(Driver,true);
        loginPage.Login();
    }

    [Test]
    [SmokeTest]
    public void AddSingleForAllTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver, true);
        addProjectPage.AddProject(Project.Name, Project.Announcement,true, Project.Type[0]);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(Driver).IsPageOpened());
    }

    [Test]
    [SmokeTest]
    public void AddSingleBaselineTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver,true);
        addProjectPage.AddProject(Project.Name, Project.Announcement,true, Project.Type[1]);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(Driver).IsPageOpened());
    }

    [Test]
    [SmokeTest]
    public void AddMultipleTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver,true);
        addProjectPage.AddProject(Project.Name, Project.Announcement,false, Project.Type[2]);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(Driver).IsPageOpened());
    }

    [Test]
    public void RadioProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver,true);
        addProjectPage.AddProject1(Project.Name, Project.Announcement,3,true);
        
        Assert.IsTrue(new SuccessfullyAddedProjectPage(Driver).IsPageOpened());
    }
}
