using OpenQA.Selenium;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.BaseEntities;

public class BaseTest
{
    private WaitService _waitService;

    [ThreadStatic] protected static IWebDriver Driver;
    
    [SetUp]
    public void Setup()
    {
        Driver = new BrowserService().WebDriver;
        _waitService = new WaitService(Driver);
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}
