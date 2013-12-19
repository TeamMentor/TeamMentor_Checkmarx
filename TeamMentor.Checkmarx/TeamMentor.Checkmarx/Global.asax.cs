using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using log4net.Config;

namespace TeamMentor.Checkmarx
{

    public class MvcApplication : System.Web.HttpApplication
    {
        private ILog _log = LogManager.GetLogger(typeof (TeamMentor.Checkmarx.MvcApplication));

        protected void Application_Start()
        {
            XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}