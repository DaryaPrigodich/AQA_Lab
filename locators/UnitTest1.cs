using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace locators;

public class Tests
{
    private IWebDriver _driver ;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(HtmlFileAnalisis.FullPath);
    }

    [Test]
    public void TestXPath()
    {
        Assert.Multiple(() =>
        {
            var element = _driver.FindElement(By.XPath("(//*[contains(text(),'Test')])[2]"));
            Assert.IsTrue(element.Displayed);

            var element2 = _driver.FindElement(By.XPath("//*[text()='Test'][@ids]"));
            Assert.IsTrue(element2.Displayed);
            
            var element3 = _driver.FindElement(By.XPath("//*[normalize-space()='Title 2']"));
            Assert.IsTrue(element3.Displayed);
            
            var element4 = _driver.FindElement(By.XPath("//*[normalize-space()='Title 3']/parent::h1"));
            Assert.IsTrue(element4.Displayed);
            
            var element5 = _driver.FindElement(By.XPath("(//*[normalize-space()='Title 2']/ancestor::*//*[@class='arrow'])[2]"));
            Assert.IsTrue(element5.Displayed);
        });
    }
    
    [Test]
    public void TestCSSSelector()
    {
        Assert.Multiple(() =>
        {
            var element = _driver.FindElement(By.CssSelector("[id='123']"));
            Assert.IsTrue(element.Displayed);
            
            var element2 = _driver.FindElements(By.CssSelector(".arrow"));
            Assert.AreEqual(6, element2.Count);
            
            var element3 = _driver.FindElement(By.CssSelector("[id='123']"));
            Assert.IsTrue(element3.Displayed);
            
            var element4 = _driver.FindElements(By.CssSelector("h1 > *"));
            Assert.AreEqual(6, element4.Count);
            
            var element5 = _driver.FindElements(By.CssSelector("[value^='12']"));
            Assert.AreEqual(4, element5.Count);
        });
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
