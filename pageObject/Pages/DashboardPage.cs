using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;
using pageObject.Enums;

namespace pageObject.Pages;

public class DashboardPage : BasePage
{
    private const string Endpoint = "/index.php?/dashboard";

    private DropDownMenu UserMenu => new(Driver, By.Id("userDropdown"));
    private DropDownMenu HelpMenu => new(Driver, By.Id("helpDropdown"));
    private Button SidebarProjectsAdd => new(Driver, By.Id("sidebar-projects-add"));

    public DashboardPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public DashboardPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(BaseTest.BaseURL + Endpoint);
    }
    
    [AllureStep("Click to 'Add Project' button")]
    public void ClickAddProjectButton()
    {
        SidebarProjectsAdd.Click();
    }

    public int GetCountUserMenuOptions()
    {
        return UserMenu.GetCountOptions();
    }

    public int GetCountHelpMenuOptions()
    {
        return HelpMenu.GetCountOptions();
    }
    
    public string GetOptionTextHelpMenu(int index)
    {
        return HelpMenu.GetOptionText(index);
    }

    [AllureStep("Click to HelpMenu dropdown option with index {0}")]
    public void ChooseHelpMenuOptionByIndex(int optionIndex)
    {
        HelpMenu.ChooseOptionByIndex(Dropdown.HelpDropdown, optionIndex);
    }
    
    [AllureStep("Click to HelpMenu dropdown option with value {0}")]
    public void ChooseUserMenuOptionByValue(string optionValue)
    {
        UserMenu.ChooseOptionByValue(Dropdown.UserDropdown, optionValue);
    }
}
