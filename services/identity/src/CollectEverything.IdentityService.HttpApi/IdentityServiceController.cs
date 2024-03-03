using CollectEverything.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}