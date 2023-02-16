using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace pageObject.Services;

public class WaitService
{
    [ThreadStatic]
    protected static IWebDriver _driver;

    private readonly WebDriverWait _waitService;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _waitService = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
    }

    public IWebElement WaitElementIsClickable(IWebElement webElement)
    {
        return _waitService.Until(ExpectedConditions.ElementToBeClickable(webElement));
    }

    public IWebElement GetVisibleElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementIsVisible(by));
    }

    public bool IsElementInVisible(By by)
    {
        return _waitService.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
    }

    public IWebElement GetExistElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementExists(by));
    }

    public IWebElement WaitElementIsClickable(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementToBeClickable(by));
    }

    public IWebElement GetClickableElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementToBeClickable(by));
    }
}
