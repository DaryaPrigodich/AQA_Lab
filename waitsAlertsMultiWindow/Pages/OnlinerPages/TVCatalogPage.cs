using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages;

public class TVCatalogPage : BasePage
{
    private static string END_POINT = "/tv";

    private static readonly By TVCheckboxesBy = 
        By.XPath("//*[contains(@class,'compare')]/child::*[contains(@data-bind,'data: product')]");

    private static readonly By ComparisonButtonBy = By.XPath("//*[contains(@href,'/compare/')]");
    private static readonly By VKButtonBy = By.XPath("//a[contains(@href,'vk.com')]");
    private static readonly By FacebookButtonBy = By.XPath("//a[contains(@href,'facebook.com')]");
    private static readonly By TwitterButtonBy = By.XPath("//a[contains(@href,'twitter.com')]");

    private List<IWebElement> TVCheckboxes => new(Driver.FindElements(TVCheckboxesBy));
    public IWebElement VKButton => Driver.FindElement(VKButtonBy);
    public IWebElement FacebookButton => Driver.FindElement(FacebookButtonBy);
    public IWebElement TwitterButton => Driver.FindElement(TwitterButtonBy);

    private IWebElement ComparisonButton => _waitService.GetVisibleElement(ComparisonButtonBy);
    
    public TVCatalogPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    public TVCatalogPage(IWebDriver _driver) : base(_driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseOnlinerURL + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return VKButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public void CompareTwoFirstTv()
    {
        TVCheckboxes[1].Click();
        TVCheckboxes[2].Click();
        ComparisonButton.Click();
    }
  
    public void SwitchToPage(string windowHandles)
    {
        Driver.SwitchTo().Window(windowHandles);
    }
}
