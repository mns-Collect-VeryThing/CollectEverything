using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ShopsInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ShopsInstallerModule>();
        });
    }
}
