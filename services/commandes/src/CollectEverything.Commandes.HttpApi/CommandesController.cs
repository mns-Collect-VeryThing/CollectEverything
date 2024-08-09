using CollectEverything.Commandes.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.Commandes;

public abstract class CommandesController : AbpControllerBase
{
    protected CommandesController()
    {
        LocalizationResource = typeof(CommandesResource);
    }
}
