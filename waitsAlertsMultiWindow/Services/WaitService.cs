using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace waitsAlertsMultiWindow.Services;

public class WaitService
{
    [ThreadStatic] protected static IWebDriver Driver;

    private readonly WebDriverWait _waitService;

    public WaitService(IWebDriver driver)
    {
        Driver = driver;
        _waitService = new WebDriverWait(Driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
    }

    public IWebElement GetVisibleElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementIsVisible(by));
    }

    public bool IsElementInVisible(By by)
    {
        return _waitService.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
    }
}
