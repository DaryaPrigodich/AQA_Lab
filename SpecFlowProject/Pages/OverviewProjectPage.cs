using OpenQA.Selenium;

namespace SpecFlowProject.Pages;

public class OverviewProjectPage : BasePage
{
    public IWebElement MessageSuccess => WaitService.GetExistElement(By.XPath("//*[@id='content-inner']/child::*[contains(@class,'message-success')]"));
    public IWebElement DashboardButton => WaitService.GetExistElement(By.Id("navigation-dashboard"));
    public IWebElement ProjectsTable => WaitService.GetExistElement(By.ClassName("grid"));
    public IWebElement DeleteProjectButton(string projectName) => WaitService.GetExistElement(By.XPath($"//a[text()='{projectName}']/parent::td/following-sibling::*[2]"));
    public IWebElement ConfirmationDeleteProjectCheckBox => WaitService.GetExistElement(By.XPath("(//*[@name='deleteCheckbox'])[3]"));
    public IWebElement ConfirmationDeleteProjectButton => WaitService.GetExistElement(By.XPath("(//a[normalize-space()='OK'])[3]"));
    
    public OverviewProjectPage(IWebDriver driver) : base(driver)
    {
    }
    
    public bool IsPageOpened()
    {
        try
        {
            return ProjectsTable.Displayed; 
        }
        catch (Exception e)
        {
            return false;     
        }    
    }
}
