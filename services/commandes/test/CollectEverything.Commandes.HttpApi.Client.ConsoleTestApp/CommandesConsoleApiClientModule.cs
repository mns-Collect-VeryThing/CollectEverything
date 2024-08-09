using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace CollectEverything.Commandes;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CommandesHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CommandesConsoleApiClientModule : AbpModule
{

}
