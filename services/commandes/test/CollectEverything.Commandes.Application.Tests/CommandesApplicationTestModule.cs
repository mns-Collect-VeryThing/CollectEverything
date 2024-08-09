using Volo.Abp.Modularity;

namespace CollectEverything.Commandes;

[DependsOn(
    typeof(CommandesApplicationModule),
    typeof(CommandesDomainTestModule)
    )]
public class CommandesApplicationTestModule : AbpModule
{

}
