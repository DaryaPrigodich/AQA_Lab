using OpenQA.Selenium;

namespace pageObject.Core.Wrappers;

public class CheckBox
{
    private UIElement _uiElement;
    
    public CheckBox(IWebDriver driver, By by)
    {
        _uiElement = new UIElement(driver, by);
    }
    
    public string TagName => _uiElement.TagName;
    public bool Enabled => _uiElement.Enabled;
    public bool Selected => _uiElement.Selected;
    public bool Displayed => _uiElement.Displayed;

    private void DoAction(bool flag)
    {
        if (Selected != flag)
        {
            _uiElement.Click();            
        }
    }

    public void Check()
    {
        DoAction(true);
    }
    
    public void Uncheck()
    {
        DoAction(false);
    }
}
