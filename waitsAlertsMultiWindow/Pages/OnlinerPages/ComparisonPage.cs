using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using waitsAlertsMultiWindow.BaseEntities;

namespace waitsAlertsMultiWindow.Pages;

public class ComparisonPage : BasePage
{
    private static readonly By ComparedTVBy = By.XPath("//*[contains(@class,'product-table__row_top')]");
    private static readonly By ScreenDiagonalFieldBy = By.XPath("//*[text()='Диагональ экрана']");
    private static readonly By ScreenDiagonalTipButtonBy = By.XPath("//*[@data-tip-term='Диагональ экрана']");
    private static readonly By DeleteFirstTVButtonBy =
        By.XPath("(//*[@class='product-summary']/following-sibling::a)[1]");
    private static readonly By TVInformationBy =
        By.XPath("//*[@class='product-summary']//a[@class='product-summary__figure']");
    private static readonly By ScreenDiagonalTipDataBy = By.XPath("//*[@class='product-table-tip__text']");

    private IWebElement ComparedTV => Driver.FindElement(ComparedTVBy);
    private IWebElement ScreenDiagonalField => Driver.FindElement(ScreenDiagonalFieldBy);
    private IWebElement DeleteFirstTVButton => Driver.FindElement(DeleteFirstTVButtonBy);
    public List<IWebElement> TVInformation => new(Driver.FindElements(TVInformationBy));

    private IWebElement ScreenDiagonalTipButton => _waitService.GetVisibleElement(ScreenDiagonalTipButtonBy);
    private bool ScreenDiagonalTipData => _waitService.IsElementInVisible(ScreenDiagonalTipDataBy);

    public ComparisonPage(IWebDriver _driver) : base(_driver, false)
    {
    }

    protected override void OpenPage()
    {
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return ComparedTV.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public void ShowScreenDiagonalTip()
    {
        var actions = new Actions(Driver);
        actions.MoveToElement(ScreenDiagonalField).Perform();
        
        ScreenDiagonalTipButton.Click();
    }
    
    public bool HideScreenDiagonalTip()
    {
        ScreenDiagonalTipButton.Click();
        return ScreenDiagonalTipData;
    }
    
    public void DeleteFirstTv()
    {
        DeleteFirstTVButton.Click();
    }
}
