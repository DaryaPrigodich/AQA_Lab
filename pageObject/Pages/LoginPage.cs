using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;
using pageObject.Services;

namespace pageObject.Pages;

public class LoginPage : BasePage
{
    private const string Endpoint = "";

    private UIElement EmailInput => new (Driver,By.Id("name"));
    private UIElement PswInput => new (Driver, By.Id("password"));
    private Button LoginButton => new (Driver, By.Id("button_primary"));
    
    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public LoginPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(BaseTest.BaseURL + Endpoint);
    }
    
    [AllureStep("Login with user email {0} and password {1}")]
    public void Login(string email, string password)
    {
        EmailInput.SendKeys(email);
        PswInput.SendKeys(password);
        LoginButton.Click();
    }
}
