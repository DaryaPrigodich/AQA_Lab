using OpenQA.Selenium;
using pageObject.BaseEntities;

namespace pageObject.Pages;

public class DashboardPage : BasePage
{
    private static string END_POINT = "/index.php?/dashboard"; 
    
    private static readonly By SidebarProjectsAddButtonBy = By.Id("sidebar-projects-add");

    public DashboardPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    public DashboardPage(IWebDriver _driver) : base(_driver, false)
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
            return SidebarProjectsAddButton.Displayed; 
        }
        catch (Exception e)
        {
            return false;     
        }    
    }

    public IWebElement SidebarProjectsAddButton => Driver.FindElement(SidebarProjectsAddButtonBy);
}
