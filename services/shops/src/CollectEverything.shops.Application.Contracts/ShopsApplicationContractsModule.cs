using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(ShopsDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ShopsApplicationContractsModule : AbpModule
{

}
