using Localization.Resources.AbpUi;
using CollectEverything.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace CollectEverything.Product;

[DependsOn(
    typeof(ProductApplicationContractsModule)
    )]
public class ProductHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ProductResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
