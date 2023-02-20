using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages;

public class TwitterPage : BasePage
{
    private const string EndPoint = "/OnlinerBY";

    private static readonly By SignUpButtonBy = By.XPath("//span[text()='Зарегистрироваться']");
     
    public IWebElement SignUpButton => Driver.FindElement(SignUpButtonBy);
    
    public TwitterPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public TwitterPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseTwitterUrl + EndPoint);
    }
}
