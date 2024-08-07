using CollectEverything.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.Product;

public abstract class ProductController : AbpControllerBase
{
    protected ProductController()
    {
        LocalizationResource = typeof(ProductResource);
    }
}
