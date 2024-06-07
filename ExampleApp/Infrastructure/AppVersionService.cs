﻿using System.Reflection;

namespace ExampleApp.Infrastructure;

public interface IAppVersionService
{
    string Version { get; }
}

internal class AppVersionService : IAppVersionService
{
    public string Version
    {
        get => GetVersionFromAssembly();
    }

    public static string GetVersionFromAssembly()
    {
        string strVersion = default!;
        var versionAttribute = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (versionAttribute != null)
        {
            var version = versionAttribute.InformationalVersion;
            var plusIndex = version.IndexOf('+');
            if (plusIndex >= 0 && plusIndex + 9 < version.Length)
            {
                strVersion = version[..(plusIndex + 9)];
            }
            else
            {
                strVersion = version;
            }
        }

        return strVersion;
    }
}