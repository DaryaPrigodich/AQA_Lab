using waitsAlertsMultiWindow.BaseEntities;
using waitsAlertsMultiWindow.Pages;

namespace waitsAlertsMultiWindow;

public class WaitTests : BaseTest
{
    [Test]
    public void WaitTest()
    {
        var tvCatalogPage = new TVCatalogPage(Driver,true);
        tvCatalogPage.CompareTwoFirstTv();

        var comparisonPage = new ComparisonPage(Driver);
        comparisonPage.ShowScreenDiagonalTip();

        Assert.IsTrue(comparisonPage.HideScreenDiagonalTip());

        comparisonPage.DeleteFirstTv();

        Assert.AreEqual(2, comparisonPage.TVInformation.Count);
    }
}
