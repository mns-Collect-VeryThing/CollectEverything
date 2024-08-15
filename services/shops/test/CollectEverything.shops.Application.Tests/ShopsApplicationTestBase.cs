using Volo.Abp.Modularity;

namespace CollectEverything.Shops;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class ShopsApplicationTestBase<TStartupModule> : ShopsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
