using OpenQA.Selenium;
using SpecFlowProject.Services;

namespace SpecFlowProject.Pages;

public class LoginPage : BasePage
{
    public IWebElement EmailInput =>  WaitService.GetExistElement( By.Id("name"));
    public IWebElement PswInput =>  WaitService.GetExistElement(By.Id("password"));
    public IWebElement LoginButton =>   WaitService.GetExistElement(By.Id("button_primary"));

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }
    
    public void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }
}
