using System.Reflection;
using Microsoft.Extensions.Configuration;
using SpecFlowProject.Models;
using SpecFlowProject.Models.Enum;

namespace SpecFlowProject.Services;

public class Configurator
{
    private static readonly Lazy<IConfiguration> _configuration;
    private static IConfiguration Configuration => _configuration.Value;

    static Configurator()
    {
        _configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile("appsettings.json");
        return builder.Build();
    }

    public static AppSettings AppSettings
    {
        get
        {
            var appSettings = new AppSettings();
            var child = Configuration.GetSection("AppSettings");
            appSettings.URL = child["URL"];
            return appSettings;
        }
    }

    private static List<User?> Users
    {
        get
        {
            List<User?> users = new List<User?>();
            var child = Configuration.GetSection("Users");
            foreach (var section in child.GetChildren())
            {
                var user = new User { Password = section["Password"], Username = section["Username"] };
                user.UserType = section["UserType"].ToLower() switch
                {
                    "admin" => UserType.Admin,
                    "user" => UserType.User,
                    _ => user.UserType
                };
                users.Add(user);
            }

            return users;
        }
    }

    public static User? Admin => Users.Find(x => x?.UserType == UserType.Admin);
    public static User? User => Users.Find(x => x?.UserType == UserType.User);
    public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);
    public static string ChromeBrowser => Configuration[nameof(ChromeBrowser)];
}
