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
        addProjectPage.AddNewProject(Project.Name, Project.Announcement,true, 1);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(Driver).IsPageOpened(), "Project hasn't been added.");
    }

    [Test]
    [SmokeTest]
    public void AddSingleBaselineTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver,true);
        addProjectPage.AddNewProject(Project.Name, Project.Announcement,true,2);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(Driver).IsPageOpened(), "Project hasn't been added.");
    }

    [Test]
    [SmokeTest]
    public void AddMultipleTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver,true);
        addProjectPage.AddNewProject(Project.Name, Project.Announcement,false,3);

        Assert.IsTrue(new SuccessfullyAddedProjectPage(Driver).IsPageOpened(), "Project hasn't been added.");
    }
}
