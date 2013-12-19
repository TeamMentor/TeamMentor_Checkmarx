//O2File:CxWSResolver.cs

using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using FluentSharp.CoreLib;
using log4net;
using TeamMentor.Checkmarx;

namespace Checkmarx712
{
    [WebService(Namespace = "http://Checkmarx.com")]
    public class CxWSResolver
    {
        public CxWSResolver_Proxy _web_Service { get; set; }
        private ILog log = LogManager.GetLogger(typeof(CxWSResolver));
        public CxWSResolver()
        {
            var config = new CXConfiguration();
            var data = config.secretData_Load();
            if (data.notNull() && data.CheckMarx_WebService_EndPoint.isUri())
            {
                log.Debug("Checkmarx WebService proxy is " + data.CheckMarx_WebService_EndPoint);
                _web_Service = new CxWSResolver_Proxy(data.CheckMarx_WebService_EndPoint);
            }
            else
            {
                log.Error("Configuration file was not loaded propertly. Plase check");
                throw new Exception("CxWSResolver Could not load configuration file");
                
            }
        }

        [WebMethod()]
        public CxWSResponseDiscovery GetWebServiceUrl(CxClientType ClientType, int APIVersion)
        {

            var contex = HttpContext.Current;
            
            string servicePath = string.Empty;
          
            log.Debug("Inside GetWebServiceUrl");
            CxWSResponseDiscovery result = _web_Service.GetWebServiceUrl(ClientType, APIVersion);
            if (result.notNull() && result.IsSuccesfull)
            {
                
                log.Debug(String.Format("Original url  {0}", result.ServiceURL));
                if (result.ServiceURL.isUri())
                {
                    var webserviceUrl = new Uri(result.ServiceURL);
                    if (servicePath.notNull() && webserviceUrl.Segments.notNull())
                    {
                        var endPoint = webserviceUrl.Segments.LastOrDefault();
                        switch (endPoint)
                        {
                            case "CxAuditWebService.asmx":
                                servicePath = "CxWebInterface/Audit/CxAuditWebService.asmx";
                                break;
                            case "CxEclipseWebService.asmx":
                                servicePath = "CxWebInterface/Eclipse/CxEclipseWebService.asmx";
                                break;
                            case "CxVSWebService.asmx":
                                servicePath = "CxWebInterface/VS/CxVSWebService.asmx";
                                break;
                            case "CxWebService.asmx":
                                servicePath = "CxWebInterface/Portal/CxWebService.asmx";
                                break;
                            default:
                                return result;
                            break;
                               
                        }
                        var newUrl = contex.Request.Url.hostUrl();
                        var portNumber = contex.Request.Url.Port.ToString();

                        if (!String.IsNullOrEmpty(portNumber))
                            newUrl = contex.Request.Url.hostUrl().EndsWith(":")
                                ? newUrl + ":" + portNumber + "/"
                                : newUrl + ":" + portNumber;

                        if (!newUrl.EndsWith("/"))
                            newUrl += "/" + servicePath;
                        else newUrl += servicePath;


                        result.ServiceURL = newUrl;
                        log.Debug("New URL " + newUrl);

                    }
                }
                else
                {
                    log.Error(String.Format("{0} is not a valid URI",result.ServiceURL));
                    throw new ArgumentException(String.Format("{0} is not a valid URI", result.ServiceURL));
                }
                return result;
            }
            return result;
        }
    }
}
