using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Pages.AlertPages;

namespace waitsAlertsMultiWindow;

public class AlertTests : BaseTest
{
    [Test]
    public void AlertTest()
    {
        var alertPage = new AlertPage(Driver, true);
        var simpleAlert = alertPage.ShowSimpleAlert();
        alertPage.AcceptSimpleAlert(simpleAlert);

        var confirmationAlert = alertPage.ShowConfirmationAlert();
        var confirmationAlertMessage = alertPage.AcceptConfirmationAlert(confirmationAlert);
        Assert.IsTrue(confirmationAlertMessage.Displayed, "You didn't confirm an alert.");

        confirmationAlert = alertPage.ShowConfirmationAlert();
        confirmationAlertMessage = alertPage.DismissConfirmationAlert(confirmationAlert);
        Assert.That(confirmationAlertMessage.GetAttribute("innerText"), Is.EqualTo("You selected Cancel"), "You didn't cancel an alert.");

        var promptAlert = alertPage.ShowPromptAlert();
        alertPage.EnterTextIntoPromptAlert(promptAlert);
        var promptAlertMessage = alertPage.AcceptPromptAlert(promptAlert);
        Assert.AreEqual("You entered Great site", promptAlertMessage.GetAttribute("innerText"), "You entered wrong text.");
    }
}
