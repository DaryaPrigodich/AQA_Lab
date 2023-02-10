using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages;

public class VkPage : BasePage
{
    private static string END_POINT = "/onliner";

    private static readonly By SignInButtonBy = By.XPath("//button[contains(@data-action,'sign_in')]");

    private IWebElement SignInButton => Driver.FindElement(SignInButtonBy);

    public VkPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    public VkPage(IWebDriver _driver) : base(_driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseVkURL + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return SignInButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
