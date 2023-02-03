using OpenQA.Selenium;
using pageObject.Enums;
using pageObject.Pages;

namespace pageObject.Steps;

public class AddProjectSteps
{
    private IWebDriver Driver;

    public AddProjectSteps(IWebDriver driver)
    {
        Driver = driver;
    }

    public void AddProject(string nameProject, string announcement, Enum type)
    {
        var addProjectPage = new AddProjectPage(Driver, true);
        addProjectPage.NameProjectInput.SendKeys(nameProject);
        addProjectPage.AnnouncementInput.SendKeys(announcement);
        switch (type)
        {
            case ProjectType.SingleForAll:
                addProjectPage.SingleForAllType.Click();
                break;
            case ProjectType.SingleBaseline:
                addProjectPage.SingleBaselineType.Click();
                break;
            case ProjectType.Multiple:
                addProjectPage.MultipleType.Click();
                break;
        }
        addProjectPage.AddProjectButton.Click();
    }
}
