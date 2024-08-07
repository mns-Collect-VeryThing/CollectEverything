using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CollectEverything.Product.EntityFrameworkCore
{
    public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProductDbContext>()
                .UseNpgsql(GetConnectionStringFromConfiguration());
            return new ProductDbContext(builder.Options);
        }
        
        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(ProductDbProperties.ConnectionStringName);
        }
        
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory())?.Parent!.FullName!,
                        $"host{Path.DirectorySeparatorChar}CollectEverything.Product.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", false);

            return builder.Build();
        }
    }
}