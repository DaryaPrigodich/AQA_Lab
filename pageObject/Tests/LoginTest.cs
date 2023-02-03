using pageObject.BaseEntities;
using pageObject.Pages;
using pageObject.Steps;

namespace pageObject;

public class LoginTest : BaseTest
{
    [Test]
    [SmokeTest]
    public void LoginValidDataTest()
    {
        var loginSteps = new LoginSteps(_driver);
        loginSteps.Login();
        
        Assert.IsTrue(new DashboardPage(_driver).IsPageOpened()); 
        Assert.AreEqual(_driver.Title, "All Projects - TestRail");
    }
}
