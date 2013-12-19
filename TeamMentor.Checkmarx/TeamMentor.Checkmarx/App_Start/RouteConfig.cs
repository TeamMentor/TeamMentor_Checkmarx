using System;
using System.Web.Mvc;
using System.Web.Routing;
using FluentSharp.CoreLib;
using log4net;

namespace TeamMentor.Checkmarx
{
    public class RouteConfig
    {
        private const string Version626 = "TeamMentor.Checkmarx.Versions._626.wsdl.xml";
        private const string Version629 = "TeamMentor.Checkmarx.Versions._629.wsdl.xml";
        private const string Version712 = "TeamMentor.Checkmarx.Versions._7._712.wsdl.xml";


        private static readonly ILog Log = LogManager.GetLogger(typeof(RouteConfig));
        public static void RegisterRoutes(RouteCollection routes)
        {
            Log.Debug("Registering Routes");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            Log.Debug("Reading Configuration file....");
      
            var config = new CXConfiguration();
            var data = config.secretData_Load();
            var servicePath = string.Empty;
            var serviceUrl = String.Empty;

            //Safe check for configuration file
            if (data.notNull())
            {
                var serviceEndPoint = data.CheckMarx_WebService_EndPoint;

                //Safe check for checkmarx WebService.
                if (serviceEndPoint != null && serviceEndPoint.isUri())
                {
                    serviceEndPoint += "?wsdl";
                    //Getting Wsdl from the original server
                    var originalServiceWsdl = serviceEndPoint.GET();
                    if (originalServiceWsdl == null) 
                        throw new NullReferenceException("originalServiceWsdl was null");
                    //Getting XML messages
                    var wsdlMessages = originalServiceWsdl.GetWsdlMessages();

                    if (wsdlMessages.Equals(Version626.GetXmlResponseFromFile().GetWsdlMessages()))
                    {
                        serviceUrl = "CxWebInterface/CxWebService.asmx";
                        servicePath = "~/Versions/626/CxWebService.asmx";
                        Log.Debug("Checkmarx version 6.2.6 found. Registering URL " + serviceUrl);
                    }
                    else if (wsdlMessages.Equals(Version629.GetXmlResponseFromFile().GetWsdlMessages()))
                    {
                        serviceUrl = "CxWebInterface/CxWebService.asmx";
                        servicePath = "~/Versions/629/CxWebService.asmx";
                        Log.Debug("Checkmarx version 6.2.9 found. Registering URL " + serviceUrl);
                    } else if (wsdlMessages.Equals(Version712.GetXmlResponseFromFile().GetWsdlMessages()))
                    {
                        serviceUrl = "CxWebInterface/CxWSResolver.asmx";
                        servicePath = "~/Versions/7/712/CxWSResolver.asmx"; 
                        //Registering URl for other services
                        //Audit
                        routes.MapWebServiceRoute("RouteAuditService", "CxWebInterface/Audit/CxAuditWebService.asmx", "~/Versions/7/712/Audit/CxAuditWebService.asmx");
                        //Eclipse
                        routes.MapWebServiceRoute("RouteEclipseService", "CxWebInterface/Eclipse/CxEclipseWebService.asmx", "~/Versions/7/712/Eclipse/CxEclipseWebService.asmx");
                        //VisualStudio
                        routes.MapWebServiceRoute("RouteVisualStudioService", "CxWebInterface/VS/CxVSWebService.asmx", "~/Versions/7/712/VS/CxVSWebService.asmx");
                        //Portal
                        routes.MapWebServiceRoute("RoutePortalService", "CxWebInterface/Portal/CxWebService.asmx", "~/Versions/7/712/Web/CxWebService.asmx");
                        Log.Debug("Checkmarx version 7 found");
                    }
                    else
                    {
                        Log.Error("WSDL not supported.Please verify what Checkmarx version and Patch is up and running.");
                       return;
                    }
                    //Registering Routes
                    routes.MapWebServiceRoute("Route"+servicePath, serviceUrl, servicePath);
                }
                else
                {
                    Log.Error(String.Format("{0} is not a valid URI ", data.CheckMarx_WebService_EndPoint));
                    throw new ArgumentException(
                        String.Format("Configuration setting for CheckMarx_WebService_EndPoint is not a valid URI" +
                                      "Value found {0}", data.CheckMarx_WebService_EndPoint));
                }
            }
            else
                Log.Error(
                    "Error loading/reading configuration file. This file is required to get WebServices EndPoint and TeamMentor Url.");

            Log.Debug("Routes registered succesfully");
        }
       
    }
}