using Volo.Abp.Modularity;

namespace CollectEverything.Shops;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class ShopsDomainTestBase<TStartupModule> : ShopsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
