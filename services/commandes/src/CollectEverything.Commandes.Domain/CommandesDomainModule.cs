using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace CollectEverything.Commandes;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CommandesDomainSharedModule)
)]
public class CommandesDomainModule : AbpModule
{

}
