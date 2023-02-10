using pageObject.BaseEntities;
using pageObject.Pages;

namespace pageObject;

public class LoginTest : BaseTest
{
    [Test]
    [SmokeTest]
    public void LoginValidDataTest()
    {
        var loginPage = new LoginPage(Driver,true);
        loginPage.Login();
        
        Assert.AreEqual(Driver.Title, "All Projects - TestRail");
    }
}
