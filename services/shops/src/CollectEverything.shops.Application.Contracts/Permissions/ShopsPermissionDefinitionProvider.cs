using CollectEverything.Shops.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CollectEverything.Shops.Permissions;

public class ShopsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ShopsPermissions.GroupName, L("Permission:Shops"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ShopsResource>(name);
    }
}
