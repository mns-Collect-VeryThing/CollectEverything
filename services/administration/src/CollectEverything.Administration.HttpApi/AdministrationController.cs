using CollectEverything.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.Administration;

public abstract class AdministrationController : AbpControllerBase
{
    protected AdministrationController()
    {
        LocalizationResource = typeof(AdministrationResource);
    }
}