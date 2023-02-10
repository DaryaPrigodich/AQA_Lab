using jsexecutorFrameActions.BaseEntities;
using jsexecutorFrameActions.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace jsexecutorFrameActions.Pages;

public class CatalogPage : BasePage
{
    private static string END_POINT = "";
    
    private static readonly By SearchInputBy = By.XPath("//input[@name='query']");
    private static readonly By FrameBy = By.XPath("//iframe[contains(@src,'search')]");
    private static readonly By FirstProductNameBy = By.XPath("//*[@class='product__title']/child::a");
    private static readonly By FirstProductBy = By.XPath("//*[@class='product__preview']");

    private IWebElement SearchInput => _waitService.GetVisibleElement(SearchInputBy);
    private IWebElement Frame => _waitService.GetVisibleElement(FrameBy);
    private IWebElement FirstProductName => _waitService.GetVisibleElement(FirstProductNameBy);
    private IWebElement FirstProduct => _waitService.GetVisibleElement(FirstProductBy);

    public CatalogPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    public CatalogPage(IWebDriver _driver) : base(_driver, false)
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
            return SearchInput.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public void SearchProduct()
    {
        var jsExecutor = (IJavaScriptExecutor)Driver;
        jsExecutor.ExecuteScript("arguments[0].click();",SearchInput);
        SearchInput.SendKeys("Тостер");
    }
    
    public string GetFullFirstProductName()
    {
        return FirstProductName.GetAttribute("innerText");
    }

    public void SwitchToFrame()
    {
        Driver.SwitchTo().Frame(Frame);
    }

    public void SearchFullProductName(string productName)
    {
        var actions = new Actions(Driver);
        actions.KeyDown(Keys.Control)
            .SendKeys("a")
            .KeyUp(Keys.Control)
            .KeyDown(Keys.Backspace)
            .SendKeys(productName)
            .Click(FirstProduct)
            .Build()
            .Perform();
    }
}
