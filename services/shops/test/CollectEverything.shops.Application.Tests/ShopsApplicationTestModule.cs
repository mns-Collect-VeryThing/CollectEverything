using Volo.Abp.Modularity;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(ShopsApplicationModule),
    typeof(ShopsDomainTestModule)
    )]
public class ShopsApplicationTestModule : AbpModule
{

}
