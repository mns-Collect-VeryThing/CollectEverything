using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CollectEverything.Commandes.EntityFrameworkCore;

[DependsOn(
    typeof(CommandesDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CommandesEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CommandesDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddDefaultRepositories(true);
        });
    }
}
