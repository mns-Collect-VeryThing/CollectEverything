using CollectEverything.Commandes.Localization;
using Volo.Abp.Application.Services;

namespace CollectEverything.Commandes;

public abstract class CommandesAppService : ApplicationService
{
    protected CommandesAppService()
    {
        LocalizationResource = typeof(CommandesResource);
        ObjectMapperContext = typeof(CommandesApplicationModule);
    }
}
