using jsexecutorFrameActions.BaseEntities;
using jsexecutorFrameActions.Pages;

namespace jsexecutorFrameActions;

public class Tests : BaseTest
{
    [Test]
    public void Test1()
    {
        var catalogPage = new CatalogPage(Driver, true);
        catalogPage.SearchProduct();
        catalogPage.SwitchToFrame();
        var productName = catalogPage.GetFullFirstProductName();
        catalogPage.SearchFullProductName(productName);

        var productPage = new ProductPage(Driver);
        var actualProductName = productPage.GetActualProductName();
        
        Assert.AreEqual(productName, actualProductName);
    }
}
