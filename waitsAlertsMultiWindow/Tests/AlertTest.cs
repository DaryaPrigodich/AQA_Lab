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
        Console.Out.WriteLine(simpleAlert.Text);
        alertPage.AcceptSimpleAlert(simpleAlert);

        var confirmationAlert = alertPage.ShowConfirmationAlert();
        Console.Out.WriteLine(confirmationAlert.Text);
        var confirmationAlertMessage = alertPage.AcceptConfirmationAlert(confirmationAlert);
        Assert.IsTrue(confirmationAlertMessage.Displayed);

        confirmationAlert = alertPage.ShowConfirmationAlert();
        confirmationAlertMessage = alertPage.DismissConfirmationAlert(confirmationAlert);
        Assert.AreEqual("You selected Cancel", confirmationAlertMessage.GetAttribute("innerText"));

        var promptAlert = alertPage.ShowPromptAlert();
        Console.Out.WriteLine(promptAlert.Text);
        alertPage.EnterTextIntoPromptAlert(promptAlert);
        var promptAlertMessage = alertPage.AcceptPromptAlert(promptAlert);
        Assert.AreEqual("You entered Great site", promptAlertMessage.GetAttribute("innerText"));
    }
}
