using CollectEverything.Commandes.Paniers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace CollectEverything.Commandes.EntityFrameworkCore;

[ConnectionStringName(CommandesDbProperties.ConnectionStringName)]
public class CommandesDbContext : AbpDbContext<CommandesDbContext>, ICommandesDbContext
{
    public DbSet<Panier> Panier { get; set; }
    public DbSet<Article> Articles { get; set; }

    public CommandesDbContext(DbContextOptions<CommandesDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCommandes();
        
        if (builder.IsHostDatabase())
        {
            builder.Entity<Panier>(commande =>
            {
                commande.ToTable(CommandesDbProperties.DbTablePrefix + "Commandes", CommandesDbProperties.DbSchema);
                commande.ConfigureByConvention();
                commande.HasMany(c => c.ArticleJoinEntities).WithOne().HasForeignKey(je => je.ArticleId).IsRequired();
            });
            
            builder.Entity<Article>(article =>
            {
                article.ToTable(CommandesDbProperties.DbTablePrefix + "Articles", CommandesDbProperties.DbSchema);
                article.ConfigureByConvention();
            });

            builder.Entity<ArticleDansPanierJoinEntity>(ap =>
            {
                ap.ToTable(CommandesDbProperties.DbTablePrefix + "ArticleDansPanierJoinEntities",
                    CommandesDbProperties.DbSchema);
                ap.ConfigureByConvention();

                ap.HasKey(je => new { je.PanierId, je.ArticleId });

                ap.HasOne<Panier>().WithMany(p => p.ArticleJoinEntities).HasForeignKey(je => je.PanierId).IsRequired();
                ap.HasOne<Article>().WithMany().HasForeignKey(je => je.ArticleId).IsRequired();
                
                ap.HasIndex(je => new { je.PanierId, je.ArticleId });
            });
        }
    }
}
