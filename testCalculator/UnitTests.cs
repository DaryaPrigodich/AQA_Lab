using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace testCalculator;

public class Tests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
    }

    [Test]
    public void TestLaminateCalc()
    {
        _driver.Navigate().GoToUrl(@"https://calc.by/building-calculators/laminate.html");

        var laminateDropDown = new SelectElement(_driver.FindElement(By.Id("laying_method_laminate")));
        laminateDropDown.SelectByValue("2");

        var roomLength = _driver.FindElement(By.Id("ln_room_id"));
        roomLength.Clear();
        roomLength.SendKeys("500");

        var roomWidth = _driver.FindElement(By.Id("wd_room_id"));
        roomWidth.Clear();
        roomWidth.SendKeys("400");

        var laminatePanelLength = _driver.FindElement(By.Id("ln_lam_id"));
        laminatePanelLength.Clear();
        laminatePanelLength.SendKeys("2000");

        var laminatePanelWidth = _driver.FindElement(By.Id("wd_lam_id"));
        laminatePanelWidth.Clear();
        laminatePanelWidth.SendKeys("200");

        var laminateLayingDirection = _driver.FindElement(By.Id("direction-laminate-id1"));
        laminateLayingDirection.Click();

        var countButton = _driver.FindElement(By.XPath("//*[text() = 'Рассчитать']"));
        countButton.Click();

        Thread.Sleep(5000);

        var requiredLaminate = _driver.FindElement(By.XPath("//*[text()= '53']"));
        Assert.AreEqual("53", requiredLaminate.GetAttribute("innerText"));

        var requiredLaminatePack =
            _driver.FindElement(By.XPath("//*[text()= '7']"));
        Assert.AreEqual("7", requiredLaminatePack.Text);
    }
    
    [Test]
    public void TestCaloriesCalc()
    {
        _driver.Navigate().GoToUrl(@"https://www.calc.ru/kalkulyator-kalorii.html");
        
        var physicalActivity = new SelectElement(_driver.FindElement(By.Id("activity")));
        physicalActivity.SelectByValue("1.4625");

        var age = _driver.FindElement(By.Id("age"));
        age.SendKeys("35");

        var weight = _driver.FindElement(By.Id("weight"));
        weight.SendKeys("85");

        var height = _driver.FindElement(By.Id("sm"));
        height.SendKeys("185");
        
        var countButton = _driver.FindElement(By.Id("submit"));
        countButton.Click();

        Thread.Sleep(5000);

        var requiredCaloriesPerDay = _driver.FindElement(By.XPath("//td[contains(text(), '3028 ккал/день')]"));
        Assert.AreEqual("3028 ккал/день", requiredCaloriesPerDay.GetAttribute("innerText"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}

