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
public class LoginTest : BaseTest
{
    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Login Feature")]
    public void LoginValidDataTest()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.Login(Configurator.Username, Configurator.Password);
        
        Driver.Title.Should().Match("All Projects - TestRail","Invalid credentials.");
    }
}
