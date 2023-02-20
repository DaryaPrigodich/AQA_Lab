using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using pageObject.BaseEntities;
using pageObject.Pages;
using pageObject.Services;

namespace pageObject;

[TestFixture]
[AllureNUnit]
public class DashboardTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.Login(Configurator.Username, Configurator.Password);
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Add project")]
    public void AddProjectButtonTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        dashboardPage.ClickAddProjectButton();
        Driver.Title.Should().Be("Add Project - TestRail", "Button isn't clickable.");
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Dropdown menu")]
    public void ChooseOptionByIndexTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        dashboardPage.ChooseHelpMenuOptionByIndex(3);
        Driver.WindowHandles.Count.Should().Be(2,"Option page wasn't open.");
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Dropdown menu")]
    public void ChooseOptionByValueTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        dashboardPage.ChooseUserMenuOptionByValue("My Settings");
        Driver.Title.Should().Be("My Settings - TestRail","Option page wasn't open.");
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Dropdown menu")]
    public void CountDropDownOptionsTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        var countUserMenuOptions = dashboardPage.GetCountUserMenuOptions();
        countUserMenuOptions.Should().Be(2,"Wrong number of options.");
        
        var countHelpMenuOptions = dashboardPage.GetCountHelpMenuOptions();
        countHelpMenuOptions.Should().Be(9,"Wrong number of options.");
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Dropdown menu")]
    public void OptionTextTest()
    {
        var dashboardPage = new DashboardPage(Driver);
        var optionText = dashboardPage.GetOptionTextHelpMenu(3);
        optionText.Should().Contain("Keyboard Shortcuts","Invalid option text.");
    }
}
