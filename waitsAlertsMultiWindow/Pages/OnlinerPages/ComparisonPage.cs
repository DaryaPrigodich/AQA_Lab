using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using waitsAlertsMultiWindow.BaseEntities;

namespace waitsAlertsMultiWindow.Pages;

public class ComparisonPage : BasePage
{
    private IWebElement ScreenDiagonalField => Driver.FindElement(By.XPath("//*[text()='Диагональ экрана']"));
    private IWebElement DeleteFirstTvButton => Driver.FindElement(By.XPath("(//*[@class='product-summary']/following-sibling::a)[1]"));
    public List<IWebElement> TvInformation => new(Driver.FindElements(By.XPath("//*[@class='product-summary']//a[@class='product-summary__figure']")));

    private IWebElement ScreenDiagonalTipButton => WaitService.GetVisibleElement(By.XPath("//*[@data-tip-term='Диагональ экрана']"));
    private bool ScreenDiagonalTipData => WaitService.IsElementInVisible(By.XPath("//*[@class='product-table-tip__text']"));

    public ComparisonPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
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
        DeleteFirstTvButton.Click();
    }
}
