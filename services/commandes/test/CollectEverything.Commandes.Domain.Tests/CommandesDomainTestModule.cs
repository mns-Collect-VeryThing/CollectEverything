using Volo.Abp.Modularity;

namespace CollectEverything.Commandes;

[DependsOn(
    typeof(CommandesDomainModule),
    typeof(CommandesTestBaseModule)
)]
public class CommandesDomainTestModule : AbpModule
{

}
