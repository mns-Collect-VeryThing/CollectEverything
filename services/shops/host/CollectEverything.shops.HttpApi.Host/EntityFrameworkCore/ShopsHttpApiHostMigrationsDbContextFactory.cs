using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CollectEverything.Shops.EntityFrameworkCore;

public class ShopsHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ShopsHttpApiHostMigrationsDbContext>
{
    public ShopsHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ShopsHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Shops"));

        return new ShopsHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
