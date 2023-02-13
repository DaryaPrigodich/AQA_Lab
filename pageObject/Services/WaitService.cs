using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace pageObject.Services;

public class WaitService
{
    [ThreadStatic] protected static IWebDriver _driver;

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

    public IWebElement GetExistElement(By by)
    {
        try
        {
            return _waitService.Until(ExpectedConditions.ElementExists(by));
        }
        catch (Exception e)
        {
            throw new AssertionException(e.Message);
        }
    }

    public IWebElement WaitElementIsClickable(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementToBeClickable(by));
    }
}
