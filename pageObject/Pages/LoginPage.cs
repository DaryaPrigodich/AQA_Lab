using OpenQA.Selenium;
using pageObject.BaseEntities;

namespace pageObject.Pages;

public class LoginPage : BasePage
{
    private static string END_POINT = ""; 
    
    private static readonly By EmailInputBy = By.Id("name");
    private static readonly By PswInputBy = By.Id("password");
    private static readonly By LoginButtonBy = By.Id("button_primary");

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
    
    public IWebElement EmailInput => Driver.FindElement(EmailInputBy);
    public IWebElement PswInput => Driver.FindElement(PswInputBy);
    public IWebElement LoginButton => Driver.FindElement(LoginButtonBy);
}
