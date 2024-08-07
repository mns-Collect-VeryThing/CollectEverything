using CollectEverything.Product.Localization;
using Volo.Abp.Application.Services;

namespace CollectEverything.Product;

public abstract class ProductAppService : ApplicationService
{
    protected ProductAppService()
    {
        LocalizationResource = typeof(ProductResource);
        ObjectMapperContext = typeof(ProductApplicationModule);
    }
}
