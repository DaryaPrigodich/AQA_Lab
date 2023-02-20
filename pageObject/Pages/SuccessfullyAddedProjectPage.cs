using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;

namespace pageObject.Pages;

public class SuccessfullyAddedProjectPage : BasePage
{
    private const string Endpoint = "/index.php?/admin/projects/overview";

    private UIElement MessageSuccess => new(Driver, By.XPath("//*[@id='content-inner']/child::*[contains(@class,'message-success')]"));

    public SuccessfullyAddedProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public SuccessfullyAddedProjectPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(BaseTest.BaseURL + Endpoint);
    }

    public bool IsPageOpened()
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
}
