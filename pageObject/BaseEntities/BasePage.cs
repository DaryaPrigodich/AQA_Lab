using OpenQA.Selenium;

namespace pageObject.BaseEntities;

public abstract class BasePage
{
    protected static IWebDriver Driver;

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
