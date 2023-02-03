using pageObject.BaseEntities;
using pageObject.Steps;

namespace pageObject;

public class DashboardTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
        var loginSteps = new LoginSteps(_driver);
        loginSteps.Login();
    }
    
    [Test]
    [SmokeTest]
    public void AddProjectButtonTest()
    {
        var dashboardSteps = new DashboardSteps(_driver);
        dashboardSteps.ClickAddProjectButton();
        
        Assert.AreEqual(_driver.Title,"Add Project - TestRail");
    }
}
