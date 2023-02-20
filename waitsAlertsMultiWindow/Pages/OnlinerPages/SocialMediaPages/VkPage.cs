using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages;

public class VkPage : BasePage
{
    private const string Endpoint = "/onliner";
    
    private IWebElement SignInButton => Driver.FindElement(By.XPath("//button[contains(@data-action,'sign_in')]"));

    public VkPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public VkPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseVkUrl + Endpoint);
    }

    public bool IsPageOpened()
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
