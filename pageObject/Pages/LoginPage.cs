using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Services;

namespace pageObject.Pages;

public class LoginPage : BasePage
{
    private static string END_POINT = ""; 
    
    private static readonly By EmailInputBy = By.Id("name");
    private static readonly By PswInputBy = By.Id("password");
    private static readonly By LoginButtonBy = By.Id("button_primary");

    private IWebElement EmailInput => Driver.FindElement(EmailInputBy);
    private IWebElement PswInput => Driver.FindElement(PswInputBy);
    private IWebElement LoginButton => Driver.FindElement(LoginButtonBy);
    
    public LoginPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }
    
    public LoginPage(IWebDriver _driver) : base(_driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(BaseTest.BaseURL + END_POINT);
    }

    public override bool IsPageOpened()
    {
        try
        {
            return LoginButton.Displayed; 
        }
        catch (Exception e)
        {
            return false;     
        }    
    }
    
    public void Login()
    {
        EmailInput.SendKeys(Configurator.Username);
        PswInput.SendKeys(Configurator.Password);
        LoginButton.Click();
    }
}
