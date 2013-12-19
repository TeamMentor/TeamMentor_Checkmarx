using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using log4net;
using log4net.Config;
using TeamMentor.Checkmarx;

/// <summary>
/// Summary description for CxTeamMentor_Mappings
/// </summary>
public class CxTeamMentor_Mappings
{
    #region static variables 
    public static Dictionary<int, string> Tm_QueryId_Mappings { get; set; }
    public static string HtmlRedirectTemplate { get; set; }
    private static ILog log = LogManager.GetLogger(typeof (CxTeamMentor_Mappings));
    private static CXConfiguration config;
    #endregion

    #region class contructor
    static CxTeamMentor_Mappings()
    {
        XmlConfigurator.Configure();
        Tm_QueryId_Mappings = new Dictionary<int, string>();
        log.Debug("Loading XML mapping...");
        try
        {
            config = new CXConfiguration();
            LoadData();
        }
        catch (Exception exception)
        {
            log.Error(String.Format("There was an error loading TeamMentor XML file. {0} {1}", exception.Message, exception.StackTrace));
            throw;
        }
        
    }

    #endregion    

    #region Methods
    public static void LoadData()
    {
        var teamMentorLibrary = config.secretData_Load().TeamMentor_Vulnerabilities_Server_URL;
        log.Debug(String.Format("Using TeamMentor Vulnerability library located at " + teamMentorLibrary));

        HtmlRedirectTemplate = "<html><head><meta http-equiv=\"refresh\" content=\"0;" +
                               "url=" + teamMentorLibrary + "/article/{0}\"></head></html>";

        //var file = HostingEnvironment.MapPath(@"/App_Code/CheckMarxMapping.xml");
        string file;
        if (AppDomain.CurrentDomain.BaseDirectory.EndsWith(@"\"))
        {
            file = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\CheckMarxMapping.xml";
        }
        else
            file = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\CheckMarxMapping.xml";

        if (log.IsDebugEnabled)
            log.Debug("Loading XML File : " + file);

        string xmlResult;
        try
        {
            using (var fs = File.OpenRead(file))
            {
                var sw = new StreamReader(fs);
                xmlResult = sw.ReadToEnd();
            }
            CheckMarxDataMapping checkMarxDataMapping;

            var serializer = new XmlSerializer(typeof(CheckMarxDataMapping));
            using (var reader = new StringReader(xmlResult))
                checkMarxDataMapping = (CheckMarxDataMapping) serializer.Deserialize(reader);
            //Loading a Dictionary
            if (checkMarxDataMapping != null && checkMarxDataMapping.Mapping !=null)
            {
                checkMarxDataMapping.Mapping.ForEach(x => Tm_QueryId_Mappings.Add(x.QueryId, x.Guid));
            }
        }
        catch
        (Exception EX_NAME)
        {
            log.Error(EX_NAME.ToString());
            throw;
        }
        if (log.IsDebugEnabled)
            log.Debug(String.Format("[LoadData] {0} mapping elements found", Tm_QueryId_Mappings.Count));


    }

    #endregion

}

[Serializable]
public class DataItem
{
    [XmlAttribute]
    public int QueryId { get; set; }

    [XmlAttribute]
    public String Guid { get; set; }
}

[Serializable]
public class CheckMarxDataMapping
{
    [XmlArray]
    public List<DataItem> Mapping;

    public CheckMarxDataMapping()
    {
        Mapping = new List<DataItem>();
    }
}

