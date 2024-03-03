using CollectEverything.SaaS.Localization;
using Volo.Abp.Application.Services;

namespace CollectEverything.SaaS;

public abstract class SaaSAppService : ApplicationService
{
    protected SaaSAppService()
    {
        LocalizationResource = typeof(SaaSResource);
        ObjectMapperContext = typeof(SaaSApplicationModule);
    }
}