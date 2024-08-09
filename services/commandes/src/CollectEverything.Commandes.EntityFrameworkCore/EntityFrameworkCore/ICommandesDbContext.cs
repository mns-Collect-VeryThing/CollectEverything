using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Commandes.EntityFrameworkCore;

[ConnectionStringName(CommandesDbProperties.ConnectionStringName)]
public interface ICommandesDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
