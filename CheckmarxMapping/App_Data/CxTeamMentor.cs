using System;
using System.Collections.Generic;
using System.Linq;
using  log4net;
using log4net.Config;
using O2.DotNetWrappers.ExtensionMethods;

/// <summary>
///     Summary description for CxTeamMentor
/// </summary>
public class CxTeamMentor


{
    private static readonly long TeamMentorIdentifier = 1000000;
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

        if (cweId > TeamMentorIdentifier)
        {
            cxWsResponseQueryDescription.QueryDescription =
                !CxTeamMentor_Mappings.Tm_QueryId_Mappings.ContainsKey(cweId)
                    ? String.Format("The TeamMentor article with Id {0} could not be found",cweId)
                    : String.Format(CxTeamMentor_Mappings.HtmlRedirectTemplate, CxTeamMentor_Mappings.Tm_QueryId_Mappings[cweId]);
            cxWsResponseQueryDescription.IsSuccesfull = true;
            cxWsResponseQueryDescription.ErrorMessage="";
        }
        log.Debug("HTML reponse " + cxWsResponseQueryDescription.QueryDescription);
    }

    public void TMFilterFor_CxWSResponseScanResults(CxWSResponseScanResults result)
    {
        //var cxXmlResults = new CxXMLResults();
        var cxXmlResults = result.ScanResults.ascii().deserialize<CxXMLResults>(false);
    }
}