using OpenQA.Selenium;

namespace SpecFlowProject.Pages;

public class DashboardPage : BasePage
{
    public IWebElement SidebarProjectsAddButton =>  WaitService.GetExistElement( By.Id("sidebar-projects-add"));
    public IWebElement MilestoneButton(string projectName) =>  WaitService.GetExistElement( By.XPath($"//*[text()='{projectName}']/parent::div/following-sibling::*/descendant::a[2]"));

    public DashboardPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsPageOpened()
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
}
