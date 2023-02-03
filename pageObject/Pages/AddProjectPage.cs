using OpenQA.Selenium;
using pageObject.BaseEntities;

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
    
    public IWebElement NameProjectInput => Driver.FindElement(NameProjectInputBy);
    public IWebElement AnnouncementInput => Driver.FindElement(AnnouncementInputBy);
    public IWebElement SingleForAllType => Driver.FindElement(SingleForAllTypeBy);
    public IWebElement SingleBaselineType => Driver.FindElement(SingleBaselineTypeBy);
    public IWebElement MultipleType => Driver.FindElement(MultipleTypeBy);
    public IWebElement AddProjectButton => Driver.FindElement(AddProjectButtonBy);
}
