using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages;

public class AddProjectPage : BasePage
{
    public IWebElement NameProjectInput => WaitService.GetExistElement(By.Id("name"));
    public IWebElement AnnouncementInput =>  WaitService.GetExistElement(By.Id("announcement"));
    public IWebElement AddProjectButton =>  WaitService.GetExistElement(By.Id("accept"));
    public IWebElement ShowAnnouncementCheckBox =>  WaitService.GetExistElement(By.Id("show_announcement"));
    public ReadOnlyCollection<IWebElement> RadioModes => Driver.FindElements(By.XPath("//*[@name='suite_mode']"));
    
    public AddProjectPage(IWebDriver driver) : base(driver)
    {
    }
}
