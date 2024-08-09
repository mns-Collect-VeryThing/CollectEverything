using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CollectEverything.Commandes.EntityFrameworkCore
{
    public class CommandesDbContextFactory : IDesignTimeDbContextFactory<CommandesDbContext>
    {
        public CommandesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CommandesDbContext>()
                .UseNpgsql(GetConnectionStringFromConfiguration());
            return new CommandesDbContext(builder.Options);
        }
        
        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(CommandesDbProperties.ConnectionStringName);
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