using System.Reflection;
using System.Text.Json;
using NLog;

namespace PhoneStore;

public static class JsonAnalysis
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private const string FileName = "appsettings.json";
    private static readonly string BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    private static readonly string FullPath = $"{BasePath}{System.IO.Path.DirectorySeparatorChar}{FileName}";

    private static string ReadJson()
    {
        string json;
        
        try
        {
            json = File.ReadAllText(FullPath);
        }
        catch (FileNotFoundException e)
        {
            _logger.Error(e.Message);
            throw;
        }
       
        return json;
    }

    public static void DeserializeJsonFile()
    {
        var json = ReadJson();
        
        Data.RootObject = JsonSerializer.Deserialize<RootObject>(json);
    }
}
