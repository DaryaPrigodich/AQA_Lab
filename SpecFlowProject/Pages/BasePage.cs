using OpenQA.Selenium;
using SpecFlowProject.Services;

namespace SpecFlowProject.Pages;

public abstract class BasePage
{
    protected static IWebDriver Driver;
    protected static WaitService? WaitService;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);
    }
}
