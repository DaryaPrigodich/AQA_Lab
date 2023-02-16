using OpenQA.Selenium;
using pageObject.Services;

namespace pageObject.BaseEntities;

public abstract class BasePage
{
    [ThreadStatic] 
    protected static IWebDriver Driver;
    protected WaitService _waitService;

    protected abstract void OpenPage();

    protected BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;

        if (openPageByUrl)
        {
            OpenPage();
        }
    }
}
