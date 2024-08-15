using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace CollectEverything.Shops;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ShopsHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ShopsConsoleApiClientModule : AbpModule
{

}
