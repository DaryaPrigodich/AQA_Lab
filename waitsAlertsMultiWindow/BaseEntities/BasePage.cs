using OpenQA.Selenium;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.BaseEntities;

public abstract class BasePage
{
    [ThreadStatic] 
    protected static IWebDriver Driver;
    protected WaitService WaitService;

    protected abstract void OpenPage();

    protected BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);

        if (openPageByUrl)
        {
            OpenPage();
        }
    }
}
