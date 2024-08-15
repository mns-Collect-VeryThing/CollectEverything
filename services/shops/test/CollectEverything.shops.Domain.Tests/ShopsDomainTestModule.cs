using Volo.Abp.Modularity;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(ShopsDomainModule),
    typeof(ShopsTestBaseModule)
)]
public class ShopsDomainTestModule : AbpModule
{

}
