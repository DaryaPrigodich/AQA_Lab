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

    private ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _uiElement.FindElements(by);
    }

    private IWebElement FindElement(By by)
    {
        return _uiElement.FindElement(by);
    }

    private ReadOnlyCollection<IWebElement> Options => FindElements(By.TagName("a"));
    
    private void OpenDropDownMenu(Enum dropDownName)
    {
        var dropdown = FindElement(By.XPath($"//a[contains(@href,'{dropDownName}')]"));
        
        if (Options[0].Displayed)
        {
            throw new InvalidOperationException("Dropdown is opened.");
        }

        dropdown.Click();
    }

    public int GetCountOptions()
    {
        return Options.Count;
    }

    public string GetOptionText(int index)
    {
        return Options[index].GetAttribute("innerText");
    }

    public void ChooseOptionByIndex(Enum dropDownName,int optionIndex)
    {
        OpenDropDownMenu(dropDownName);
        
        try
        {
            Options[optionIndex].Click();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Out.WriteLine("Option with such index doesn't exist.");
            throw;
        }
    }
    
    public void ChooseOptionByValue(Enum dropDownName, string optionValue)
    {
        OpenDropDownMenu(dropDownName);
        try
        {
            FindElement(By.XPath($"//*[contains(text(),'{optionValue}')]")).Click();
        }
        catch (NoSuchElementException e)
        {
            Console.WriteLine("Option with such value doesn't exist.");
            throw;
        }
    }
}
