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

        Assert.AreEqual(Driver.Title, "Add Project - TestRail", "Button isn't clickable.");
    }

    [Test]
    public void ChooseOptionByIndexTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        dashboardPage.ChooseHelpMenuOptionByIndex(3);
        Assert.AreEqual(2, Driver.WindowHandles.Count, "Option page wasn't open.");
    }

    [Test]
    public void ChooseOptionByValueTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        dashboardPage.ChooseUserMenuOptionByValue("My Settings");
        Assert.AreEqual(Driver.Title, "My Settings - TestRail", "Option page wasn't open.");
    }

    [Test]
    public void CountDropDownOptionsTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        var countUserMenuOptions = dashboardPage.GetCountUserMenuOptions();
        Assert.AreEqual(2,countUserMenuOptions, "Wrong number of options.");
        
        var countHelpMenuOptions = dashboardPage.GetCountHelpMenuOptions();
        Assert.AreEqual(9,countHelpMenuOptions);
    }

    [Test]
    public void OptionTextTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        var optionText = dashboardPage.GetOptionTextHelpMenu(3);
        Assert.IsTrue(optionText.Contains("Keyboard Shortcuts"), "Invalid option text.");
    }
}
