using CollectEverything.Product.Articles;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace CollectEverything.Product.EntityFrameworkCore;

[ConnectionStringName(ProductDbProperties.ConnectionStringName)]
public class ProductDbContext : AbpDbContext<ProductDbContext>, IProductDbContext
{
    public DbSet<Article> Articles { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureProduct();

        if (builder.IsHostDatabase())
        {
            builder.Entity<Article>(article =>
            {
                article.ConfigureByConvention();
                article.ToTable(ProductDbProperties.DbTablePrefix + "Article", ProductDbProperties.DbSchema);
            });
        }
    }
}
