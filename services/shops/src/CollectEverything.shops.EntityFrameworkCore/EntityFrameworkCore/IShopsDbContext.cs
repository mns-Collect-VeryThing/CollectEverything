using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Shops.EntityFrameworkCore;

[ConnectionStringName(ShopsDbProperties.ConnectionStringName)]
public interface IShopsDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
