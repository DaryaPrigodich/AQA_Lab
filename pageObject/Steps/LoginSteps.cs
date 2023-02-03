using OpenQA.Selenium;
using pageObject.Pages;
using pageObject.Services;

namespace pageObject.Steps;

public class LoginSteps
{
    private IWebDriver Driver;

    public LoginSteps(IWebDriver driver)
    {
        Driver = driver;
    }

    public void Login()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.EmailInput.SendKeys(Configurator.Username);
        loginPage.PswInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Click();
    }
}
