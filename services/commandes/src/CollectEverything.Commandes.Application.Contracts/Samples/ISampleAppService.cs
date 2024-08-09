using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace CollectEverything.Commandes.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
