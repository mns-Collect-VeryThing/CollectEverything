using CollectEverything.Commandes.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CollectEverything.Commandes.Permissions;

public class CommandesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CommandesPermissions.GroupName, L("Permission:Commandes"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CommandesResource>(name);
    }
}
