using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace pageObject.Services;

public class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    private static IConfiguration Configuration => s_configuration.Value;

    public static string BaseURL => Configuration[nameof(BaseURL)];
    public static string Username => Configuration[nameof(Username)];
    public static string Password => Configuration[nameof(Password)];
    public static string BrowserType => Configuration[nameof(BrowserType)];

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        var appsettingsFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");
        foreach (var appsettingsFile in appsettingsFiles)
        {
            builder.AddJsonFile(appsettingsFile);
        }

        return builder.Build();
    }
}
