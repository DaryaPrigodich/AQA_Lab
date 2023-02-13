using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;

namespace pageObject.Pages;

public class DashboardPage : BasePage
{
    private static string END_POINT = "/index.php?/dashboard";

    private static readonly By SidebarProjectsAddButtonBy = By.Id("sidebar-projects-add");
    private static readonly By NavigationUserBy = By.Id("userDropdown");
    private static readonly By NavigationMenuBy = By.Id("helpDropdown");

    private IWebElement NavigationUserDropDown => Driver.FindElement(NavigationUserBy);

    private DropDownMenu NavigationUser => new(Driver, NavigationUserDropDown);
    private DropDownMenu NavigationMenu => new(Driver, NavigationMenuBy);
    private Button SidebarProjectsAdd => new(Driver, SidebarProjectsAddButtonBy);

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
            return SidebarProjectsAdd.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public int GetCountUserDropDownOptions()
    {
        return NavigationUser.GetCountOptions();
    }

    public void ClickAddProjectButton()
    {
        SidebarProjectsAdd.Click();
    }
}
