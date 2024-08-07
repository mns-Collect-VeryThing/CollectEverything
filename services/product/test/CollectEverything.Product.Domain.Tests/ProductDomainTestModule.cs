using Volo.Abp.Modularity;

namespace CollectEverything.Product;

[DependsOn(
    typeof(ProductDomainModule),
    typeof(ProductTestBaseModule)
)]
public class ProductDomainTestModule : AbpModule
{

}
