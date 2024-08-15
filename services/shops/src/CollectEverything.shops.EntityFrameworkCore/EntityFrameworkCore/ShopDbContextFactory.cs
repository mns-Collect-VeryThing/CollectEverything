using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CollectEverything.Shops.EntityFrameworkCore
{
    public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopsDbContext>
    {
        public ShopsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ShopsDbContext>()
                .UseNpgsql(GetConnectionStringFromConfiguration());
            return new ShopsDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(ShopsDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory())?.Parent!.FullName!,
                        $"host{Path.DirectorySeparatorChar}CollectEverything.Shops.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", false);

            return builder.Build();
        }
    }
}