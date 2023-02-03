using OpenQA.Selenium;
using pageObject.Pages;

namespace pageObject.Steps;

public class DashboardSteps
{
    private IWebDriver Driver;

    public DashboardSteps(IWebDriver driver)
    {
        Driver = driver;
    }

    public void ClickAddProjectButton()
    {
        var dashboardPage = new DashboardPage(Driver);
        dashboardPage.SidebarProjectsAddButton.Click();
    }
}
