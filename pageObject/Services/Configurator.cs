using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace pageObject.Services;

public class Configurator
{
    private static readonly Lazy<IConfiguration> _configuration;
    private static IConfiguration Configuration => _configuration.Value;

    public static string ChromeBrowser => Configuration[nameof(ChromeBrowser)];
    public static string FireFoxBrowser => Configuration[nameof(FireFoxBrowser)];
    public static string BaseURL => Configuration[nameof(BaseURL)];
    public static string Username => Configuration[nameof(Username)];
    public static string Password => Configuration[nameof(Password)];
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
