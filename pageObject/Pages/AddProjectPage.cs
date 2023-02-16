using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;

namespace pageObject.Pages;

public class AddProjectPage : BasePage
{
    private static string END_POINT = "/index.php?/admin/projects/add/1";

    private UIElement NameProjectInput => new(Driver, By.Id("name"));
    private UIElement AnnouncementInput => new(Driver, By.Id("announcement"));
    private Button AddProject => new(Driver, By.Id("accept"));
    private CheckBox ShowAnnouncement => new(Driver, By.Id("show_announcement"));
    private Radio Radio => new(Driver, By.XPath("//*[@name='suite_mode']"));

    public AddProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public AddProjectPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(BaseTest.BaseURL + END_POINT);
    }

    public void AddNewProject(string nameProject, string announcement, bool checkbox, int radioValue)
    {
        NameProjectInput.SendKeys(nameProject);
        AnnouncementInput.SendKeys(announcement);
        if (checkbox)
        {
            ShowAnnouncement.Check();
        }
        Radio.ChooseRadioMode(radioValue);
        AddProject.Click();
    }
}
