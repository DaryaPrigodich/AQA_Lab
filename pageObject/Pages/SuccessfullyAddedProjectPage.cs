using OpenQA.Selenium;
using pageObject.BaseEntities;

namespace pageObject.Pages;

public class SuccessfullyAddedProjectPage : BasePage
{
    private static string END_POINT = "/index.php?/admin/projects/overview"; 
    
    private static readonly By MessageSuccessBy = By.XPath("//*[@id='content-inner']/child::*[contains(@class,'message-success')]");

    public SuccessfullyAddedProjectPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }
    
    public SuccessfullyAddedProjectPage(IWebDriver _driver) : base(_driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(BaseTest.BaseURL + END_POINT);
    }

    public override bool IsPageOpened()
    {
        try
        {
            return MessageSuccess.Displayed; 
        }
        catch (Exception e)
        {
            return false;     
        }    
    }
    
    public IWebElement MessageSuccess => Driver.FindElement(MessageSuccessBy);
}
