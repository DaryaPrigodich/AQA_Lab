using OpenQA.Selenium;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.BaseEntities;

public abstract class BasePage
{
    private static readonly int WAIT_FOR_PAGE_LOADING_TIME = 60;
    [ThreadStatic] protected static IWebDriver Driver;
    protected WaitService _waitService;

    protected abstract void OpenPage();
    protected abstract bool IsPageOpened();

    protected BasePage(IWebDriver _driver, bool openPageByUrl)
    {
        Driver = _driver;
        
        _waitService = new WaitService(Driver);

        if (openPageByUrl)
        {
            OpenPage();
        }

        WaitForOpen();
    }

    private void WaitForOpen()
    {
        var secondsCount = 0;
        var isPageOpenedIndicator = IsPageOpened();

        while (!isPageOpenedIndicator && secondsCount < WAIT_FOR_PAGE_LOADING_TIME)
        {
            Thread.Sleep(1000);
            secondsCount++;
            isPageOpenedIndicator = IsPageOpened();
        }

        if (!isPageOpenedIndicator)
        {
            throw new AssertionException("Page wasn't opened");
        }
    }
}
