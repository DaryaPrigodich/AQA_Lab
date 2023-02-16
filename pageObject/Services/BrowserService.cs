using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace pageObject.Services;

public class BrowserService
{
    public IWebDriver WebDriver { get; }

    public BrowserService(string browserName)
    {
        switch (browserName.ToLower())
        {
            case "chrome" : var chromeOptions = new DriverOptionsProvider().GetChromeDriverOptions();
                WebDriver = new ChromeDriver(chromeOptions);
                break;
            case "firefox" : var ffoptions = new DriverOptionsProvider().GetFirefoxDriverOptions();
                WebDriver = new FirefoxDriver(ffoptions);
                break;
            default: throw new Exception("Incorrect Browser Name.");
        }
        
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}
