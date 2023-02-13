using System.Collections.ObjectModel;
using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Core.Wrappers;
using pageObject.Enums;

namespace pageObject.Pages;

public class AddProjectPage : BasePage
{
    private static string END_POINT = "/index.php?/admin/projects/add/1";

    private static readonly By NameProjectInputBy = By.Id("name");
    private static readonly By AnnouncementInputBy = By.Id("announcement");
    private static readonly By CheckBoxBy = By.Id("show_announcement");
    private static readonly By SingleForAllTypeBy = By.Id("suite_mode_single");
    private static readonly By SingleBaselineTypeBy = By.Id("suite_mode_single_baseline");
    private static readonly By MultipleTypeBy = By.Id("suite_mode_multi");
    private static readonly By AddProjectButtonBy = By.Id("accept");

    //private static readonly By RadioBy = By.XPath("//*[@type='radio']"); 
    private static readonly By RadioBy = By.XPath("//*[@name='suite_mode']");

    private UIElement NameProjectInput => new(Driver, NameProjectInputBy);
    private UIElement AnnouncementInput => new(Driver, AnnouncementInputBy);
    private UIElement SingleForAllType => new(Driver, SingleForAllTypeBy);
    private UIElement SingleBaselineType => new(Driver, SingleBaselineTypeBy);
    private UIElement MultipleType => new(Driver, MultipleTypeBy);
    private Button AddProjectButton => new(Driver, AddProjectButtonBy);
    private CheckBox CheckBox => new(Driver, CheckBoxBy);
    private Radio Radio => new(Driver, RadioBy);

    public AddProjectPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    public AddProjectPage(IWebDriver _driver) : base(_driver, false)
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
            return AddProjectButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public void AddProject(string nameProject, string announcement, bool checkbox, Enum type)
    {
        NameProjectInput.SendKeys(nameProject);
        AnnouncementInput.SendKeys(announcement);
        if (checkbox)
        {
            CheckBox.Check();
        }

        switch (type)
        {
            case ProjectType.SingleForAll:
                SingleForAllType.Click();
                break;
            case ProjectType.SingleBaseline:
                SingleBaselineType.Click();
                break;
            case ProjectType.Multiple:
                MultipleType.Click();
                break;
        }

        AddProjectButton.Click();
    }
    
    public string RadioText(int index)
    {
        return Radio.RadioText(index) ;
    }
    
    public void AddProject1(string nameProject, string announcement, int radioValue, bool checkbox)
    {
        NameProjectInput.SendKeys(nameProject);
        AnnouncementInput.SendKeys(announcement);
        if (checkbox)
        {
            CheckBox.Check();
        }
        
        Radio.ChooseRadioMode(radioValue);

        AddProjectButton.Click();
    }
}
