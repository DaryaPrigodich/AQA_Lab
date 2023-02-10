using OpenQA.Selenium;
using pageObject.BaseEntities;
using pageObject.Enums;

namespace pageObject.Pages;

public class AddProjectPage : BasePage
{
    private static string END_POINT = "/index.php?/admin/projects/add/1"; 
    
    private static readonly By NameProjectInputBy = By.Id("name");
    private static readonly By AnnouncementInputBy = By.Id("announcement");
    private static readonly By SingleForAllTypeBy = By.Id("suite_mode_single");
    private static readonly By SingleBaselineTypeBy = By.Id("suite_mode_single_baseline");
    private static readonly By MultipleTypeBy = By.Id("suite_mode_multi");
    private static readonly By AddProjectButtonBy = By.Id("accept");

    private IWebElement NameProjectInput => Driver.FindElement(NameProjectInputBy);
    private IWebElement AnnouncementInput => Driver.FindElement(AnnouncementInputBy);
    private IWebElement SingleForAllType => Driver.FindElement(SingleForAllTypeBy);
    private IWebElement SingleBaselineType => Driver.FindElement(SingleBaselineTypeBy);
    private IWebElement MultipleType => Driver.FindElement(MultipleTypeBy);
    private IWebElement AddProjectButton => Driver.FindElement(AddProjectButtonBy);
    
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
    
    public void AddProject(string nameProject, string announcement, Enum type)
    {
        NameProjectInput.SendKeys(nameProject);
        AnnouncementInput.SendKeys(announcement);
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
}
