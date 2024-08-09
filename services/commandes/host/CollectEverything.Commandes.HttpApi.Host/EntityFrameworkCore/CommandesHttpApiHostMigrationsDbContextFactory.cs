using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CollectEverything.Commandes.EntityFrameworkCore;

public class CommandesHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CommandesHttpApiHostMigrationsDbContext>
{
    public CommandesHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CommandesHttpApiHostMigrationsDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Commandes"));

        return new CommandesHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
