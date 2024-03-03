using CollectEverything.Projects.Localization;
using Volo.Abp.Application.Services;

namespace CollectEverything.Projects;

public abstract class ProjectsAppService : ApplicationService
{
    protected ProjectsAppService()
    {
        LocalizationResource = typeof(ProjectsResource);
        ObjectMapperContext = typeof(ProjectsApplicationModule);
    }
}