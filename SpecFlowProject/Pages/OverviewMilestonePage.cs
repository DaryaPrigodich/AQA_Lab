using OpenQA.Selenium;

namespace SpecFlowProject.Pages;

public class OverviewMilestonePage : BasePage
{
    public IWebElement MessageSuccess =>  WaitService.GetExistElement( By.XPath("//*[contains(text(),'Successfully')]"));
    public IWebElement Milestone(string milestoneName) =>  WaitService.GetExistElement( By.XPath($"//*[@class='summary-title" +
        $" text-ppp']//a[text()='{milestoneName}']"));
    public IWebElement EditMilestoneButton =>  WaitService.GetExistElement( By.XPath("//*[contains(@href,'edit')]"));
    public IWebElement DeleteMilestoneButton =>  WaitService.GetExistElement( By.ClassName("icon-small-delete"));
    public IWebElement ConfirmDeletionButton =>  WaitService.GetExistElement( By.XPath("(//a[contains(text(),'OK')])[3]"));
    public IWebElement SidebarAddMilestoneButton =>  WaitService.GetExistElement( By.Id("navigation-milestones-add"));
    public IWebElement AdministrationButton =>  WaitService.GetExistElement( By.Id("navigation-admin"));

    public OverviewMilestonePage(IWebDriver driver) : base(driver)
    {
    }
    
    public bool IsPageOpened()
    {
        try
        {
            return SidebarAddMilestoneButton.Displayed; 
        }
        catch (Exception e)
        {
            return false;     
        }    
    }
}
