using Allure.Commons;
using jsexecutorFrameActions.BaseEntities;
using jsexecutorFrameActions.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace jsexecutorFrameActions;

[TestFixture]
[AllureNUnit]
public class Tests : BaseTest
{
    [Test]
    [AllureTag("Smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Darya")]
    [AllureSuite("Search engine Feature")]
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
