using System.Reflection;
using System.Text.Json;

namespace PhoneStore;

public static class JsonAnalysis
{
    private const string FileName = "appsettings.json";
    private static readonly string BasePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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
            Console.WriteLine(e.Message);
            throw;
        }
       
        return json;
    }

    public static void DeserializeJsonFile(out RootObject restoredShops)
    {
        var json = ReadJson();
        
        restoredShops = JsonSerializer.Deserialize<RootObject>(json);
    }
}
