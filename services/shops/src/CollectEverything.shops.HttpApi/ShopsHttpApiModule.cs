using Localization.Resources.AbpUi;
using CollectEverything.Shops.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(ShopsApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ShopsHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ShopsHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ShopsResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
