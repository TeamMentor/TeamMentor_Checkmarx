using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using  log4net;
using log4net.Config;
using O2.DotNetWrappers.ExtensionMethods;

/// <summary>
///     Summary description for CxTeamMentor
/// </summary>
public class CxTeamMentor


{
    private static readonly long TeamMentorIdentifier = 1000000;
    private static readonly long TopIdentifier = 8000000;

    private ILog log = LogManager.GetLogger(typeof (CxTeamMentor));

    public CxTeamMentor()
    {
        XmlConfigurator.Configure();
    }

    public void TMFilterFor_CxQueryCollectionResponse(CxQueryCollectionResponse cxQueryCollectionResponse)
    {
        log.Debug("Inside TMFilterFor_CxQueryCollectionResponse method...");

        IEnumerable<CxWSQuery> queries = from queryGroup in cxQueryCollectionResponse.QueryGroups
                                         from query in queryGroup.Queries
                                         select query;


        foreach (var query in queries)
        {
            query.Cwe = TeamMentorIdentifier + query.QueryId; // set the Cwe value to the negative of the QueryId
            query.Name += "_TM"; // Temp query name minor change
        }
    }


    public void TMFilterFor_CxWSResponseResultCollection(CxWSResponseResultCollection cxWsResponseResultCollection)

    {
        log.Debug("Inside TMFilterFor_CxWSResponseResultCollection method...");

        AuditScanResult[] results = cxWsResponseResultCollection.ResultCollection.Results;

        foreach (AuditScanResult result in results)
        {
            result.CWE = TeamMentorIdentifier+ result.QueryId; // set the Cwe value to the negative of the QueryId
            result.QueryName += "_TM"; // Temp query name minor change
        }
    }


    public void TMFilterFor_CxWSResponseQueryDescription(int cweId,CxWSResponseQueryDescription cxWsResponseQueryDescription)
    {
        
        log.Debug("Inside TMFilterFor_CxWSResponseQueryDescription method...");

        log.Debug(String.Format("Getting QueryDescription for CWE {0} ",cweId));


        if (cweId > TeamMentorIdentifier && cweId < TopIdentifier)
        {
            cxWsResponseQueryDescription.QueryDescription =
                !CxTeamMentor_Mappings.Tm_QueryId_Mappings.ContainsKey(cweId)
                    ? String.Format("The TeamMentor article with Id {0} could not be found",cweId)
                    : String.Format(CxTeamMentor_Mappings.HtmlRedirectTemplate, CxTeamMentor_Mappings.Tm_QueryId_Mappings[cweId]);
        }
        else
        {
            if (cweId > TopIdentifier)
            {

                cweId = (int) ((cweId - TopIdentifier) + TeamMentorIdentifier);
                log.Debug(String.Format("Fixed CWE {0} ", cweId));
                
                var description = !CxTeamMentor_Mappings.Tm_QueryId_Mappings.ContainsKey(cweId)? string.Empty
                    : String.Format(CxTeamMentor_Mappings.HtmlRedirectTemplate, CxTeamMentor_Mappings.Tm_QueryId_Mappings[cweId]);
                if (!String.IsNullOrEmpty(description))
                {
                    var url = description.Substring(54, 76);
                    log.Debug("URL is "+ url);
                    var client = new WebClient();
                    var body = client.DownloadString(url);
                    cxWsResponseQueryDescription.QueryDescription = body;
                    client.Dispose();
                }
            }
        }
        log.Debug("HTML reponse " + cxWsResponseQueryDescription.QueryDescription);
    }

    public void TMFilterFor_CxWSResponseScanResults(CxWSResponseScanResults result)
    {
        CxXMLResults cxResults;
        using (var stream = new MemoryStream(result.ScanResults))
        {
            var serializer = new XmlSerializer(typeof(CxXMLResults));

            cxResults = (CxXMLResults) serializer.Deserialize(stream);
        }

        foreach (var xresult in cxResults.Items)
        {
            xresult.cweId = (TopIdentifier + xresult.id);
        }

        result.ScanResults = ObjectToByteArray(cxResults);

    }
    private byte[] ObjectToByteArray(Object obj)
    {
        if (obj == null)
            return null;
        var bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}