using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace waitsAlertsMultiWindow.Services;

public class WaitService
{
    [ThreadStatic] protected static IWebDriver _driver;

    private readonly WebDriverWait _waitService;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _waitService = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
    }

    public IWebElement GetVisibleElement(By by)
    {
        try
        {
            return _waitService.Until(ExpectedConditions.ElementIsVisible(by));
        }
        catch (Exception e)
        {
            throw new AssertionException(e.Message);
        }
    }

    public bool IsElementInVisible(By by)
    {
        try
        {
            return _waitService.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
        catch (Exception e)
        {
            throw new AssertionException(e.Message);
        }
    }
}
