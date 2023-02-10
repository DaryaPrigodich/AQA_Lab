using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages.AlertPages;

public class AlertPage : BasePage
{
    private static string END_POINT = "/alerts";
    
    private static readonly By SimpleAlertButtonBy = By.Id("alertButton");
    private static readonly By ConfirmationAlertButtonBy = By.Id("confirmButton");
    private static readonly By PromptAlertButtonBy = By.Id("promtButton");
    private static readonly By ConfirmationAlertMessageBy = By.Id("confirmResult");
    private static readonly By PromptAlertMessageBy = By.Id("promptResult");

    private IWebElement SimpleAlertButton => Driver.FindElement(SimpleAlertButtonBy);
    private IWebElement ConfirmationAlertButton => Driver.FindElement(ConfirmationAlertButtonBy);
    private IWebElement PromptAlertButton => Driver.FindElement(PromptAlertButtonBy);

    private IWebElement ConfirmationAlertMessage => _waitService.GetVisibleElement(ConfirmationAlertMessageBy);
    private IWebElement PromptAlertMessage => _waitService.GetVisibleElement(PromptAlertMessageBy);

    public AlertPage(IWebDriver _driver, bool openPageByUrl) : base(_driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseAlertURL + END_POINT); 
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return SimpleAlertButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }    }
    
    public IAlert ShowSimpleAlert()
    {
        SimpleAlertButton.Click();
        return Driver.SwitchTo().Alert();
    }

    public void AcceptSimpleAlert(IAlert simpleAlert)
    {
        simpleAlert.Accept();
    }
    
    public IAlert ShowConfirmationAlert()
    {
        ConfirmationAlertButton.Click();
        return Driver.SwitchTo().Alert();
    }
    
    public IWebElement AcceptConfirmationAlert(IAlert confirmationAlert)
    {
        confirmationAlert.Accept();
        return ConfirmationAlertMessage;
    }
    
    public IWebElement DismissConfirmationAlert(IAlert confirmationAlert_2)
    {
        confirmationAlert_2.Dismiss();
        return ConfirmationAlertMessage;
    }
    
    public IAlert ShowPromptAlert()
    {
        PromptAlertButton.Click();
        return Driver.SwitchTo().Alert();
    }

    public void EnterTextIntoPromptAlert(IAlert promptAlert)
    {
        promptAlert.SendKeys("Great site");
    }

    public IWebElement AcceptPromptAlert(IAlert promptAlert)
    {
        promptAlert.Accept();
        return PromptAlertMessage;
    }
}
