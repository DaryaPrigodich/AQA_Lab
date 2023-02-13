using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace pageObject.Core.Wrappers;

public class Table
{
    private UIElement _uiElement;
    private List<TableRow> _rowList = new List<TableRow>();

    public Table(IWebDriver driver,By by)
    {
        _uiElement = new UIElement(driver, by);
        foreach (var row in _uiElement.FindElements(By.TagName("tr")))
        {
            _rowList.Add(new TableRow(driver, row));
        }
    }

    public int CountRow()
    {
        return _rowList.Count;
    }

    private ReadOnlyCollection<IWebElement> Headers => _uiElement.FindElements(By.TagName("th"));
    private ReadOnlyCollection<IWebElement> Rows => _uiElement.FindElements(By.XPath("//tbody/tr"));
    private ReadOnlyCollection<IWebElement> Cells(IWebElement row) => row.FindElements(By.TagName("td"));

    public IWebElement GetElementFromCell(string columnHeader, string columnValue, string targetColumnHeader)
    {
        //перебираем все Headers до тех пор пока он не будет равен columnHeader и получаем его индекс
        var indexColumnHeader = Headers.TakeWhile(header => !header.Text.Normalize().Equals(columnHeader)).Count();
        var indexTargetColumnHeader = Headers.TakeWhile(header => !header.Text.Normalize().Equals(targetColumnHeader)).Count();

        foreach (var row in Rows)
        {
            var cells = Cells(row);
            if (cells[indexColumnHeader].Text.Normalize().Equals(columnValue))
            {
                return cells[indexTargetColumnHeader];
            }
        }

        return null;
    }
}
