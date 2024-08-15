using CollectEverything.Shops.Localization;
using Volo.Abp.Application.Services;

namespace CollectEverything.Shops;

public abstract class ShopsAppService : ApplicationService
{
    protected ShopsAppService()
    {
        LocalizationResource = typeof(ShopsResource);
        ObjectMapperContext = typeof(ShopsApplicationModule);
    }
}
