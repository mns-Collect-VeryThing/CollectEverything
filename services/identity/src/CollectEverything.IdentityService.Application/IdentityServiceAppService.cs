using CollectEverything.IdentityService.Localization;
using Volo.Abp.Application.Services;

namespace CollectEverything.IdentityService;

public abstract class IdentityServiceAppService : ApplicationService
{
    protected IdentityServiceAppService()
    {
        LocalizationResource = typeof(IdentityServiceResource);
        ObjectMapperContext = typeof(IdentityServiceApplicationModule);
    }
}