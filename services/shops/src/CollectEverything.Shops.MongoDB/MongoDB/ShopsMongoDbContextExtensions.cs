using Volo.Abp;
using Volo.Abp.MongoDB;

namespace CollectEverything.Shops.MongoDB;

public static class ShopsMongoDbContextExtensions
{
    public static void ConfigureShops(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
