using OpenQA.Selenium;

namespace SpecFlowProject.Pages;

public class AddAndEditMilestonePage : BasePage
{
    public IWebElement NameMilestoneInput => WaitService.GetExistElement(By.Id("name"));
    public IWebElement AddMilestoneButton => WaitService.GetExistElement(By.Id("accept"));
    
    public AddAndEditMilestonePage(IWebDriver driver) : base(driver)
    {
    }
}
