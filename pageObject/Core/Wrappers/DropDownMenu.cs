using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace pageObject.Core.Wrappers;

public class DropDownMenu
{
    private UIElement _uiElement;
    
    public DropDownMenu(IWebDriver driver, By by)
    {
        _uiElement = new UIElement(driver, by);
    }
    
    public DropDownMenu(IWebDriver driver,IWebElement webElement)
    {
        _uiElement = new UIElement(driver, webElement);
    }
    
    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _uiElement.FindElements(by);
    }

    public int GetCountOptions()
    {
        return Options.Count;
    }

    private ReadOnlyCollection<IWebElement> Options => _uiElement.FindElements(By.XPath("//a"));
}
