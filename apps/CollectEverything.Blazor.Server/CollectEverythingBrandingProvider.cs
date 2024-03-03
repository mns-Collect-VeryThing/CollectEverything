using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CollectEverything.Blazor.Server;

[Dependency(ReplaceServices = true)]
public class CollectEverythingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CollectEverything";
}
