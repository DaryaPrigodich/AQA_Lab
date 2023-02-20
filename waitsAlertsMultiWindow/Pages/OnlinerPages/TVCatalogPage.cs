using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages;

public class TvCatalogPage : BasePage
{
    private const string Endpoint = "/tv";

    private List<IWebElement> TvCheckboxes => new(Driver.FindElements(By.XPath("//*[contains(@class,'compare')]/child::*[contains(@data-bind,'data: product')]")));
    public IWebElement VkButton => Driver.FindElement(By.XPath("//a[contains(@href,'vk.com')]"));
    public IWebElement FacebookButton => Driver.FindElement(By.XPath("//a[contains(@href,'facebook.com')]"));
    public IWebElement TwitterButton => Driver.FindElement(By.XPath("//a[contains(@href,'twitter.com')]"));

    private IWebElement ComparisonButton => WaitService.GetVisibleElement(By.XPath("//*[contains(@href,'/compare/')]"));
    
    public TvCatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public TvCatalogPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseOnlinerUrl + Endpoint);
    }

    public void CompareTwoFirstTv()
    {
        TvCheckboxes[1].Click();
        TvCheckboxes[2].Click();
        ComparisonButton.Click();
    }
  
    public void SwitchToPage(string windowHandles)
    {
        Driver.SwitchTo().Window(windowHandles);
    }
}
