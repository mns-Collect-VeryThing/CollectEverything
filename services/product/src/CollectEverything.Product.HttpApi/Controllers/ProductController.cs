using System.Threading.Tasks;
using CollectEverything.Product.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.Product.Controllers;

// [Area(ProductRemoteServiceConsts.ModuleName)]
// [RemoteService(Name = ProductRemoteServiceConsts.RemoteServiceName)]
public abstract class ProductController : AbpControllerBase
{
    protected ProductController()
    {
        LocalizationResource = typeof(ProductResource);
    }
}
