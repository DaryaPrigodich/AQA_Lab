using OpenQA.Selenium;

namespace SpecFlowProject.Pages;

public class AdminOverviewPage : BasePage
{
    public IWebElement NavigationProjectsButton => WaitService.GetExistElement(By.Id("navigation-sub-projects"));

    public AdminOverviewPage(IWebDriver driver) : base(driver)
    {
    }
}
