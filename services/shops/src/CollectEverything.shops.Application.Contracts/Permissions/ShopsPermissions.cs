using Volo.Abp.Reflection;

namespace CollectEverything.Shops.Permissions;

public class ShopsPermissions
{
    public const string GroupName = "Shops";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ShopsPermissions));
    }
}
