using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Commandes.EntityFrameworkCore;

[ConnectionStringName(CommandesDbProperties.ConnectionStringName)]
public class CommandesDbContext : AbpDbContext<CommandesDbContext>, ICommandesDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public CommandesDbContext(DbContextOptions<CommandesDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCommandes();
        
    }
}
