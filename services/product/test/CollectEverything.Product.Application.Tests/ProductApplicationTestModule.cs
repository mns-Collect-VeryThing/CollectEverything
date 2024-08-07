using Volo.Abp.Modularity;

namespace CollectEverything.Product;

[DependsOn(
    typeof(ProductApplicationModule),
    typeof(ProductDomainTestModule)
    )]
public class ProductApplicationTestModule : AbpModule
{

}
