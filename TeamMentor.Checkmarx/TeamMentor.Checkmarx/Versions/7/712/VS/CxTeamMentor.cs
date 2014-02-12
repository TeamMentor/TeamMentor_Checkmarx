﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FluentSharp.CoreLib;
using  log4net;
using log4net.Config;

namespace Checkmarx712VS
{
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

       


        public void TMFilterFor_CxWSResponseQueryDescription(int cweId,
            CxWSResponseQueryDescription cxWsResponseQueryDescription)
        {

            log.Debug("Inside TMFilterFor_CxWSResponseQueryDescription method...");

            log.Debug(String.Format("Getting QueryDescription for CWE {0} ", cweId));


            if (cweId > TeamMentorIdentifier)
            {
                cxWsResponseQueryDescription.QueryDescription =
                    !CxTeamMentor_Mappings.Tm_QueryId_Mappings.ContainsKey(cweId)
                        ? String.Format("The TeamMentor article with Id {0} could not be found", cweId)
                        : String.Format(CxTeamMentor_Mappings.HtmlRedirectTemplate.ToString(),
                            CxTeamMentor_Mappings.Tm_QueryId_Mappings[cweId]);
            }

            log.Debug("HTML reponse " + cxWsResponseQueryDescription.QueryDescription);
        }

        public void TMFilterFor_CxWSResponseScanResults(CxWSResponseScanResults result)
        {
            var newCWE = 0;
            CxXMLResults cxResults;
            using (var stream = new MemoryStream(result.ScanResults))
            {
                var serializer = new XmlSerializer(typeof (CxXMLResults));

                cxResults = (CxXMLResults) serializer.Deserialize(stream);
            }

            //performing the TeamMentor mapping
            if (cxResults.Items != null)
            {
                foreach (var xresult in cxResults.Items)
                {
                    newCWE = Convert.ToInt32(TeamMentorIdentifier) + Convert.ToInt32(xresult.id);
                    if ((CxTeamMentor_Mappings.Tm_QueryId_Mappings.ContainsKey(newCWE)))
                    {
                        xresult.cweId = newCWE.ToString();
                    }
                }
                var bytes = Encoding.ASCII.GetBytes(cxResults.serialize(false));

                result.ScanResults = bytes;
            }
        }

        public void TMFilterFor_CxWSResponceScanResults(CxWSResponceScanResults results)
        {
            log.Debug(String.Format("Inside TMFilterFor_CxWSResponceScanResults "));

            results.Results.ToList().ForEach(item => item.QueryId = (TeamMentorIdentifier + item.QueryId));
        }

        public void TMFilterFor_CxWSResponceQuerisForScan(CxWSResponceQuerisForScan results)
        {
            log.Debug(String.Format("Inside TMFilterFor_CxWSResponceQuerisForScan "));
            var list = new List<CxWSQueryVulnerabilityData>();

            foreach (var item in results.Queries.ToList())
            {
                if ((CxTeamMentor_Mappings.Tm_QueryId_Mappings.ContainsKey((int) (TeamMentorIdentifier + item.QueryId))))
                    list.Add(item);
            }
            list.ForEach(item => item.CWE = (TeamMentorIdentifier + item.QueryId));
        }

        public void TMFilterFor_CxWSResponceQuerisForScanAndId(CxWSResponceQuerisForScanAndId results)
        {
            log.Debug(String.Format("Inside TMFilterFor_CxWSResponceQuerisForScanAndId "));
            foreach (var result in results.Queries)
            {
                if (
                    (CxTeamMentor_Mappings.Tm_QueryId_Mappings.ContainsKey((int) (TeamMentorIdentifier + result.QueryId))))
                {
                    result.CWE = (TeamMentorIdentifier + result.QueryId);
                }
            }
        }


    }
}