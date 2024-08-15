using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Shops.EntityFrameworkCore;

[ConnectionStringName(ShopsDbProperties.ConnectionStringName)]
public class ShopsDbContext : AbpDbContext<ShopsDbContext>, IShopsDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ShopsDbContext(DbContextOptions<ShopsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureShops();
    }
}
