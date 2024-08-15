using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Shops.EntityFrameworkCore;

public class ShopsHttpApiHostMigrationsDbContext : AbpDbContext<ShopsHttpApiHostMigrationsDbContext>
{
    public ShopsHttpApiHostMigrationsDbContext(DbContextOptions<ShopsHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureShops();
    }
}
