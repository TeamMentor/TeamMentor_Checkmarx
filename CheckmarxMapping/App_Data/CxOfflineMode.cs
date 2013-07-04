using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using log4net;
using log4net.Config;
using O2.DotNetWrappers.ExtensionMethods;
using System.Reflection;

/// <summary>
///     Summary description for CxTeamMentor
/// </summary>
public class CxOfflineMode
{
    public static CxWSResponseLoginData Login(Credentials applicationCredentials)
    {
        return FileContentsAsObject<CxWSResponseLoginData>("Login.xml");
    }

    public static string Util_OfflineDataFolder()
    {
        var folder = Assembly.GetExecutingAssembly()
                             .Location
                             .parentFolder()
                             .pathCombine(@"../App_Data/OfflineData");
        if (folder.dirExists())
            return folder;
        if (HttpContext.Current.notNull())
            return HttpContext.Current.Server.MapPath(@"App_Data/OfflineData");
        return null;
    }

    public static T FileContentsAsObject<T>(string fileName)
    {
        var fullPath = Util_OfflineDataFolder().pathCombine(fileName);
        if (fullPath.fileExists())
            return fullPath.deserialize<T>();
        
        return default(T);
    }
}
