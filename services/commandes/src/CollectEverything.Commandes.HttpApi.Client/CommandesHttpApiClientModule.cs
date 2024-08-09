using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace CollectEverything.Commandes;

[DependsOn(
    typeof(CommandesApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CommandesHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CommandesApplicationContractsModule).Assembly,
            CommandesRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CommandesHttpApiClientModule>();
        });

    }
}
