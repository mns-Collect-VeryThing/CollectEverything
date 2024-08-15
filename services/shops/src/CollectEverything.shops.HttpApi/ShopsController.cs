using CollectEverything.Shops.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.Shops;

public abstract class ShopsController : AbpControllerBase
{
    protected ShopsController()
    {
        LocalizationResource = typeof(ShopsResource);
    }
}
