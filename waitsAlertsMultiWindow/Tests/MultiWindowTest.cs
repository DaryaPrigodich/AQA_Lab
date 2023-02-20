using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Pages;

namespace waitsAlertsMultiWindow;

public class MultiWindow : BaseTest
{
    [Test]
    public void MultiWindowTest()
    {
        var tvCatalogPage = new TvCatalogPage(Driver, true);
        tvCatalogPage.VkButton.Click();
        var windowHandles = Driver.WindowHandles;
        tvCatalogPage.SwitchToPage(windowHandles[1]);
        
        Assert.IsTrue(new VkPage(Driver).IsPageOpened(), "VK Page wasn't open.");
        
        Driver.Close();
        tvCatalogPage.SwitchToPage(windowHandles[0]);
        tvCatalogPage.TwitterButton.Click();
        windowHandles = Driver.WindowHandles;
        tvCatalogPage.SwitchToPage(windowHandles[1]);
        var twitterPage = new TwitterPage(Driver);
        
        Assert.IsTrue(twitterPage.SignUpButton.Displayed, "Twitter Page wasn't open.");
        
        Driver.Close();
        tvCatalogPage.SwitchToPage(windowHandles[0]);
        tvCatalogPage.FacebookButton.Click();
        windowHandles = Driver.WindowHandles;
        tvCatalogPage.SwitchToPage(windowHandles[1]);
        
        Assert.AreEqual(2,windowHandles.Count, "Wrong number of open windows.");
    }
}
