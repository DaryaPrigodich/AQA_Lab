using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace pageObject.Core.Wrappers;

public class Radio
{
    private UIElement _uiElement;
    private ReadOnlyCollection<IWebElement> _radioModes;

    public Radio(IWebDriver driver, By by)
    {
        _uiElement = new UIElement(driver, by);
        _radioModes = _uiElement.FindElements(by);
    }

    public string TagName => _uiElement.TagName;
    public bool Enabled => _uiElement.Enabled;
    public bool Selected => _uiElement.Selected;
    public bool Displayed => _uiElement.Displayed;

    public int Count()
    {
        return _radioModes.Count;
    }

    public void ChooseRadioMode(int radioValue)
    {
        try
        {
            foreach (var radioMode in _radioModes)
            {
                if (int.Parse(radioMode.GetAttribute("value")).Equals(radioValue))
                {
                    radioMode.Click();
                }
            }
        }
        catch (NoSuchElementException e)
        {
            Console.WriteLine("Radio with such value doesn't exist.");
            throw;
        }
    }
}
