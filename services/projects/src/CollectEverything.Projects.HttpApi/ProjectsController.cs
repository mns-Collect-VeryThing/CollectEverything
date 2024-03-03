using CollectEverything.Projects.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CollectEverything.Projects;

public abstract class ProjectsController : AbpControllerBase
{
    protected ProjectsController()
    {
        LocalizationResource = typeof(ProjectsResource);
    }
}