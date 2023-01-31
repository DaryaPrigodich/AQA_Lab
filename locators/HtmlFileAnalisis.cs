using System.Reflection;

namespace locators;

public static class HtmlFileAnalisis
{
    private const string FileName = "index.html";
    private static readonly string BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    public static readonly string FullPath = $"file:{BasePath}{Path.DirectorySeparatorChar}Resources" +
                                             $"{Path.DirectorySeparatorChar}{FileName}";
}
