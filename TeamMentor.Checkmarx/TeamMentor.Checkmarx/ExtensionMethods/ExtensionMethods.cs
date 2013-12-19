using System;
using System.IO;
using System.Linq;
using System.Web.Routing;
using System.Xml;

namespace TeamMentor.Checkmarx
{
    public static class ExtensionMethods
    {
        public static Route MapWebServiceRoute(this RouteCollection routes, string routeName, string url, string virtualPath)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            var route = new Route(url, new RouteValueDictionary { { "controller", null }, { "action", null } }, new ServiceRouterHandler(virtualPath));
           
            routes.Add(routeName, route);
            return route;
        }

        public static string GetWsdlMessages(this string wsdl)
        {
            var xmlMessages = string.Empty;
            var doc = new XmlDocument();
            doc.LoadXml(wsdl);
            var mngr = new XmlNamespaceManager(doc.NameTable);
            mngr.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
            var result = doc.SelectNodes("wsdl:definitions/wsdl:message", mngr);

            if (result != null)
                xmlMessages = result.Cast<XmlNode>()
                            .Aggregate(xmlMessages, (current, node) => current + node.OuterXml);

            return xmlMessages;
        }
        public static string GetXmlResponseFromFile(this string resourceName)
        {
            string result = String.Empty;
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                        return result = reader.ReadToEnd();
                }
                else return "";
            }
        }
    }
}