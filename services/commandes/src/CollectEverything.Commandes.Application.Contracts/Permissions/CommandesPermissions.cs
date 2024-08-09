using Volo.Abp.Reflection;

namespace CollectEverything.Commandes.Permissions;

public class CommandesPermissions
{
    public const string GroupName = "Commandes";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CommandesPermissions));
    }
}
