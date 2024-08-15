using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CollectEverything.Shops.MongoDB;

[ConnectionStringName(ShopsDbProperties.ConnectionStringName)]
public interface IShopsMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
