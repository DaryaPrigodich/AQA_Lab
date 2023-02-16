using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;
using pageObject.Services;

namespace pageObject.Pages;

public class LoginPage : BasePage
{
    private static string END_POINT = ""; 
 
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
        Driver.Navigate().GoToUrl(BaseTest.BaseURL + END_POINT);
    }
    
    public void Login()
    {
        EmailInput.SendKeys(Configurator.Username);
        PswInput.SendKeys(Configurator.Password);
        LoginButton.Click();
    }
}
