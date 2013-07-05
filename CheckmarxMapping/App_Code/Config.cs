using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using O2.DotNetWrappers.ExtensionMethods;

public  class CXConfiguration
{
    public string CheckMarx_WebService_EndPoint { get; set; }
    public string TeamMentor_Vulnerabilities_Server_URL { get; set; }


    public CXConfiguration()
    {
        
        
    }
}

public static class CxConfig_Extension_Methods
{
    public static string cx_FileLocation(this CXConfiguration userData)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\";
        return path.pathCombine("CheckMarxConfig.config");
    }
    public static CXConfiguration secretData_Load(this CXConfiguration userData)
    {
        try
        {
             var secretDataFile = userData.cx_FileLocation();
             if (secretDataFile.fileExists())
             {
                 var secretData = secretDataFile.load<CXConfiguration>();
                 return secretData;
             }

             if (secretDataFile.notNull())
             {
                var secretData = new CXConfiguration();
                secretData.CheckMarx_WebService_EndPoint = @"http://checkmarx.teammentor.net/CxWebInterface/CxWebService.asmx";
                secretData.TeamMentor_Vulnerabilities_Server_URL = @"http://checkmarx.teammentor.net/teamMentor";
                secretDataFile.parentFolder().createDir();
                secretData.saveAs(secretDataFile);    
                return secretData;
              }
            
        }
        catch (Exception ex)
        {
            ex.log("in TM_SecretData secretData_Load");
        }

        return new CXConfiguration();
    }
}
