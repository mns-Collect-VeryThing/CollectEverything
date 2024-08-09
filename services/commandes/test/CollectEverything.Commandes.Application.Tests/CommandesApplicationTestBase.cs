using Volo.Abp.Modularity;

namespace CollectEverything.Commandes;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class CommandesApplicationTestBase<TStartupModule> : CommandesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
