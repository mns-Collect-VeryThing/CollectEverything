using Volo.Abp.Modularity;

namespace CollectEverything.Commandes;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class CommandesDomainTestBase<TStartupModule> : CommandesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
