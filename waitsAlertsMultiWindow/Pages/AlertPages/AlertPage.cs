using OpenQA.Selenium;
using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Services;

namespace waitsAlertsMultiWindow.Pages.AlertPages;

public class AlertPage : BasePage
{
    private const string Endpoint = "/alerts";

    private IWebElement SimpleAlertButton => Driver.FindElement(By.Id("alertButton"));
    private IWebElement ConfirmationAlertButton => Driver.FindElement(By.Id("confirmButton"));
    private IWebElement PromptAlertButton => Driver.FindElement(By.Id("promtButton"));

    private IWebElement ConfirmationAlertMessage => WaitService.GetVisibleElement(By.Id("confirmResult"));
    private IWebElement PromptAlertMessage => WaitService.GetVisibleElement(By.Id("promptResult"));

    public AlertPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseAlertUrl + Endpoint); 
    }

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
    
    public IWebElement DismissConfirmationAlert(IAlert confirmationAlert)
    {
        confirmationAlert.Dismiss();
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
