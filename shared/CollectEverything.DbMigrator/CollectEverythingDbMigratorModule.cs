using CollectEverything.Administration;
using CollectEverything.Administration.EntityFrameworkCore;
using CollectEverything.IdentityService;
using CollectEverything.IdentityService.EntityFrameworkCore;
using CollectEverything.Microservice.Shared;
using CollectEverything.SaaS;
using CollectEverything.SaaS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CollectEverything.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationEntityFrameworkCoreModule),
    typeof(AdministrationApplicationContractsModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaaSEntityFrameworkCoreModule),
    typeof(SaaSApplicationContractsModule)
)]
public class CollectEverythingDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}