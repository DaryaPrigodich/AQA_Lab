using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;
using pageObject.Pages;

namespace pageObject;

public class WrapperTableTest : BaseTest
{
    [Test]
    public void CountTableRowTest()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.Login();
        
        Driver.Navigate().GoToUrl("https://testtest19.testrail.io/index.php?/admin/projects/overview");
        var table = new Table(Driver, By.CssSelector("table.grid"));
        Console.Out.WriteLine(table.CountRow());
    }
}
