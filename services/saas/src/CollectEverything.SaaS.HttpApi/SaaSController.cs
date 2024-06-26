﻿using CollectEverything.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.SaaS;

public abstract class SaaSController : AbpControllerBase
{
    protected SaaSController()
    {
        LocalizationResource = typeof(SaaSResource);
    }
}