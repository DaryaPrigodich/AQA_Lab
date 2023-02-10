using pageObject.BaseEntities;
using pageObject.Pages;

namespace pageObject;

public class DashboardTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.Login();
    }
    
    [Test]
    [SmokeTest]
    public void AddProjectButtonTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        dashboardPage.ClickAddProjectButton();
        
        Assert.AreEqual(Driver.Title,"Add Project - TestRail");
    }
}
