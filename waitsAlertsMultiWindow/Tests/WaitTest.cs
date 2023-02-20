using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Pages;

namespace waitsAlertsMultiWindow;

public class WaitTests : BaseTest
{
    [Test]
    public void WaitTest()
    {
        var tvCatalogPage = new TvCatalogPage(Driver,true);
        tvCatalogPage.CompareTwoFirstTv();

        var comparisonPage = new ComparisonPage(Driver);
        comparisonPage.ShowScreenDiagonalTip();

        Assert.IsTrue(comparisonPage.HideScreenDiagonalTip(), "Screen diagonal tip wasn't hide.");

        comparisonPage.DeleteFirstTv();

        Assert.AreEqual(2, comparisonPage.TvInformation.Count, "The first TV not deleted.");
    }
}
