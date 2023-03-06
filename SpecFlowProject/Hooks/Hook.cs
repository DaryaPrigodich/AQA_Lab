using OpenQA.Selenium;
using SpecFlowProject.Services;

namespace SpecFlowProject.Hooks;

[Binding]
public sealed class Hook
{
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver _driver;
    
    public Hook(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [BeforeScenario("UI")]
    public void BeforeScenario()
    {
        _driver = new BrowserService(Configurator.ChromeBrowser).WebDriver;
        _scenarioContext.Add("Driver", _driver);
    }

    [AfterScenario("UI")]
    public void AfterScenario()
    {
        _driver.Quit();
        _scenarioContext.Remove("Driver");
    }
}
