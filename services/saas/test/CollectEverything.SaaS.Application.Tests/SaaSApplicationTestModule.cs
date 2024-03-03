using Volo.Abp.Modularity;

namespace CollectEverything.SaaS;

[DependsOn(
    typeof(SaaSApplicationModule),
    typeof(SaaSDomainTestModule)
    )]
public class SaaSApplicationTestModule : AbpModule
{

}
