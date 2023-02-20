using OpenQA.Selenium;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.BaseEntities;

public class BaseTest
{
    [ThreadStatic] 
    protected static IWebDriver Driver;
    private WaitService _waitService;
    
    [SetUp]
    public void Setup()
    {
        Driver = new BrowserService(Configurator.ChromeBrowser).WebDriver;
        _waitService = new WaitService(Driver);
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}
