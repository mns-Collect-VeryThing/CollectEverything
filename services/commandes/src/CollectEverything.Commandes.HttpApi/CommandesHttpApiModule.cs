using Localization.Resources.AbpUi;
using CollectEverything.Commandes.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace CollectEverything.Commandes;

[DependsOn(
    typeof(CommandesApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CommandesHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CommandesHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CommandesResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
