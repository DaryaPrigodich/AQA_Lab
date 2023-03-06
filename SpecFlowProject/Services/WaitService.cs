using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Services;

public class WaitService
{
    private static IWebDriver Driver;
    private readonly WebDriverWait _waitService;

    public WaitService(IWebDriver driver)
    {
        Driver = driver;
       _waitService = new WebDriverWait(Driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
    }
    
    public IWebElement GetExistElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementExists(by));
    }
}
