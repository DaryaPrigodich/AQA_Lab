using OpenQA.Selenium;

namespace pageObject.BaseEntities;

public class BaseSteps
{
    [ThreadStatic] protected static IWebDriver Driver;

    public BaseSteps(IWebDriver driver)
    {
        Driver = driver;
    }
}
