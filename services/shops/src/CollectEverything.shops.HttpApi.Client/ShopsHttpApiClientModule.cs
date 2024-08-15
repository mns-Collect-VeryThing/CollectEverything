using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(ShopsApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ShopsHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ShopsApplicationContractsModule).Assembly,
            ShopsRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ShopsHttpApiClientModule>();
        });

    }
}
