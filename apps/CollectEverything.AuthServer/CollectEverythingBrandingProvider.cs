using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CollectEverything;

[Dependency(ReplaceServices = true)]
public class CollectEverythingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CollectEverything";
}
