using jsexecutorFrameActions.BaseEntities;
using jsexecutorFrameActions.Services;
using OpenQA.Selenium;

namespace jsexecutorFrameActions.Pages;

public class ProductPage : BasePage
{
    private static string END_POINT = "";
    
    private static readonly By ProductNameBy = By.XPath("//h1");

    private IWebElement ProductName => _waitService.GetVisibleElement(ProductNameBy);
    
    public ProductPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    public ProductPage(IWebDriver _driver) : base(_driver, false)
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
            return ProductName.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public string GetActualProductName()
    {
        return ProductName.GetAttribute("innerText");
    }
}
