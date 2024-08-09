using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CollectEverything.Commandes.EntityFrameworkCore;

public class CommandesHttpApiHostMigrationsDbContext : AbpDbContext<CommandesHttpApiHostMigrationsDbContext>
{
    public CommandesHttpApiHostMigrationsDbContext(DbContextOptions<CommandesHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCommandes();
    }
}
