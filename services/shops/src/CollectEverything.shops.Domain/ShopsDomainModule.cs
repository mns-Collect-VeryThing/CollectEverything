using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ShopsDomainSharedModule)
)]
public class ShopsDomainModule : AbpModule
{

}
