using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages;

public class TwitterPage : BasePage
{
    private static string END_POINT = "/OnlinerBY";

    private static readonly By SignUpButtonBy = By.XPath("//span[text()='Зарегистрироваться']");
     
    public IWebElement SignUpButton => Driver.FindElement(SignUpButtonBy);
    
    public TwitterPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    public TwitterPage(IWebDriver _driver) : base(_driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseTwitterURL + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return SignUpButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

}
