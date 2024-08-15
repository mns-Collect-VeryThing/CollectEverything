using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CollectEverything.Shops.MongoDB;

[ConnectionStringName(ShopsDbProperties.ConnectionStringName)]
public class ShopsMongoDbContext : AbpMongoDbContext, IShopsMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureShops();
    }
}
