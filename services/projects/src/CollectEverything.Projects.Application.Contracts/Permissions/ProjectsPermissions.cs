﻿using Volo.Abp.Reflection;

namespace CollectEverything.Projects.Permissions;

public class ProjectsPermissions
{
    public const string GroupName = "Projects";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProjectsPermissions));
    }
}