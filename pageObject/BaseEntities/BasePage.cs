using OpenQA.Selenium;

namespace pageObject.BaseEntities;

public abstract class BasePage
{
    private static readonly int WAIT_FOR_PAGE_LOADING_TIME = 60;
    [ThreadStatic] protected static IWebDriver Driver;

    protected abstract void OpenPage();
    public abstract bool IsPageOpened();

    protected BasePage(IWebDriver _driver, bool openPageByUrl)
    {
        Driver = _driver;

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
