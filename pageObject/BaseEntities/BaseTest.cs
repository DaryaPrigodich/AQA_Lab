using System.Reflection;
using System.Text.Json;
using OpenQA.Selenium;
using pageObject.Models;
using pageObject.Services;

namespace pageObject.BaseEntities;

public class BaseTest
{
    public static string BaseURL = Configurator.BaseURL;
    protected Project Project;

    [ThreadStatic] 
    protected static IWebDriver Driver;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        SetUpProject();
    }
    
    [SetUp]
    public void Setup()
    {
        Driver = new BrowserService(Configurator.ChromeBrowser).WebDriver;
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }

    private void SetUpProject()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var fullPathToFile = Path.Combine(basePath, $"TestData{Path.DirectorySeparatorChar}", "project.json");

        var jsonStream = File.ReadAllText(fullPathToFile);
        Project = JsonSerializer.Deserialize<Project>(jsonStream);
    }
}
