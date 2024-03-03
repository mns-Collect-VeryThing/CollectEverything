using CollectEverything.Administration.EntityFrameworkCore;
using CollectEverything.Hosting.Shared;
using Volo.Abp.Modularity;

namespace CollectEverything.Microservice.Shared;

[DependsOn(
    typeof(CollectEverythingHostingModule),
    typeof(AdministrationEntityFrameworkCoreModule)
)]
public class CollectEverythingMicroserviceModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}