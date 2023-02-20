using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace waitsAlertsMultiWindow.Services;

public class Configurator
{
    private static readonly Lazy<IConfiguration> _configuration;
    private static IConfiguration Configuration => _configuration.Value;

    public static string ChromeBrowser => Configuration[nameof(ChromeBrowser)];
    public static string FireFoxBrowser => Configuration[nameof(FireFoxBrowser)];
    public static string BaseOnlinerUrl => Configuration[nameof(BaseOnlinerUrl)];
    public static string BaseAlertUrl => Configuration[nameof(BaseAlertUrl)];
    public static string BaseVkUrl => Configuration[nameof(BaseVkUrl)];
    public static string BaseTwitterUrl => Configuration[nameof(BaseTwitterUrl)];
    public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);

    static Configurator()
    {
        _configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");
        
        return builder.Build();
    }
}
