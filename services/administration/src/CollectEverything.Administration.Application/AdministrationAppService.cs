using CollectEverything.Administration.Localization;
using Volo.Abp.Application.Services;

namespace CollectEverything.Administration;

public abstract class AdministrationAppService : ApplicationService
{
    protected AdministrationAppService()
    {
        LocalizationResource = typeof(AdministrationResource);
        ObjectMapperContext = typeof(AdministrationApplicationModule);
    }
}