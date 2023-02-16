using OpenQA.Selenium;

namespace pageObject.Core.Wrappers;

public class Button
{
    private UIElement _uiElement;

    public Button(IWebDriver driver,By by)
    {
        _uiElement = new UIElement(driver, by);
    }
    public string TagName => _uiElement.TagName;
    public string Text => _uiElement.Text;
    public bool Enabled => _uiElement.Enabled;
    public bool Displayed => _uiElement.Displayed;
    public void Click() => _uiElement.Click();
}
