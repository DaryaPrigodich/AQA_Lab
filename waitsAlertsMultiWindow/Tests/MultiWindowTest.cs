using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Pages;

namespace waitsAlertsMultiWindow;

public class MultiWindow : BaseTest
{
    [Test]
    public void MultiWindowTest()
    {
        var tvCatalogPage = new TVCatalogPage(Driver, true);
        tvCatalogPage.VKButton.Click();
        var windowHandles = Driver.WindowHandles;
        tvCatalogPage.SwitchToPage(windowHandles[1]);
        
        Assert.AreEqual("onlíner | ВКонтакте", Driver.Title);
        
        Driver.Close();
        tvCatalogPage.SwitchToPage(windowHandles[0]);
        tvCatalogPage.TwitterButton.Click();
        windowHandles = Driver.WindowHandles;
        tvCatalogPage.SwitchToPage(windowHandles[1]);
        var twitterPage = new TwitterPage(Driver);
        
        Assert.IsTrue(twitterPage.SignUpButton.Displayed);
        
        Driver.Close();
        tvCatalogPage.SwitchToPage(windowHandles[0]);
        tvCatalogPage.FacebookButton.Click();
        windowHandles = Driver.WindowHandles;
        tvCatalogPage.SwitchToPage(windowHandles[1]);
        
        Assert.AreEqual(2,windowHandles.Count);
    }
}
