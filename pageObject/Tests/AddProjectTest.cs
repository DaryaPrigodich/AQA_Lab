using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using pageObject.BaseEntities;
using pageObject.Pages;
using pageObject.Services;

namespace pageObject;

[TestFixture]
[AllureNUnit]
public class AddProjectTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
        var loginPage = new LoginPage(Driver,true);
        loginPage.Login(Configurator.Username, Configurator.Password);
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Add project")]
    public void AddSingleForAllTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver, true);
        addProjectPage.AddNewProject(Project.Name, Project.Announcement,true, 1);
        
        new SuccessfullyAddedProjectPage(Driver).IsPageOpened().Should().BeTrue("Project hasn't been added.");
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Add project")]
    public void AddSingleBaselineTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver,true);
        addProjectPage.AddNewProject(Project.Name, Project.Announcement,true,2);
        
        new SuccessfullyAddedProjectPage(Driver).IsPageOpened().Should().BeTrue("Project hasn't been added.");
    }

    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Add project")]
    public void AddMultipleTypeProjectTest()
    {
        var addProjectPage = new AddProjectPage(Driver,true);
        addProjectPage.AddNewProject(Project.Name, Project.Announcement,false,3);
        
        new SuccessfullyAddedProjectPage(Driver).IsPageOpened().Should().BeTrue("Project hasn't been added.");
    }
}
