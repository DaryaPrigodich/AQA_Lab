using FluentAssertions;
using SpecFlowProject.Pages;
using SpecFlowProject.Services;

namespace SpecFlowProject.Steps;

[Binding]
public class LoginStepDefinitions : BaseStepDefinition
{
    private LoginPage _loginPage;

    public LoginStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _loginPage = new LoginPage(Driver);
    }

    private void GivenLoginPageIsOpen()
    {
        _loginPage.OpenPage();
    }

    private void UserEntersUsernameAndPassword()
    {
        _loginPage.EmailInput.SendKeys(Configurator.Admin.Username);
        _loginPage.PswInput.SendKeys(Configurator.Admin.Password);
    }

    private void UserClicksLoginButton()
    {
        _loginPage.LoginButton.Click();
    }
    
    private void VerifyDashboardPageIsOpen()
    {
        Driver.Title.Should().Match("All Projects - TestRail","Invalid credentials.");
    }
    
    [Given(@"user has logged in")]
    public void GivenUserHasLoggedIn()
    {
        GivenLoginPageIsOpen();
        UserEntersUsernameAndPassword();
        UserClicksLoginButton();
        VerifyDashboardPageIsOpen();
    }
}
