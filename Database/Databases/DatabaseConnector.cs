using Database.Configuration;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Databases;

public class DataBaseConnector : DbContext
{
    public DbSet<Milestone?> Milestone { get; set; } = null!;
    public DbSet<Project> Project { get; set; } = null!;

    public DataBaseConnector()
    {
        Database.EnsureCreated(); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            $"Host={Configurator.DbSettings.Server};" +
            $"Port={Configurator.DbSettings.Port};" +
            $"Database={Configurator.DbSettings.Schema};" +
            $"User Id={Configurator.DbSettings.Username};" +
            $"Password={Configurator.DbSettings.Password};";

        optionsBuilder.UseNpgsql(connectionString);
    }
}
