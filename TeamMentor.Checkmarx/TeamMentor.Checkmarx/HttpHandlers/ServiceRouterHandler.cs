using System;
using System.Web;
using System.Web.Routing;
using System.Web.Services.Protocols;

namespace TeamMentor.Checkmarx
{
 
    public class ServiceRouterHandler :IRouteHandler
    {
        #region Private variables
        private  readonly string _virtualPath;
        private readonly WebServiceHandlerFactory _handlerFactory = new WebServiceHandlerFactory();
        #endregion

        public ServiceRouterHandler(string virtualPath)
        {
            if (String.IsNullOrEmpty(virtualPath)) 
                throw new ArgumentException("VirtualPath must be entered");
            if (!virtualPath.StartsWith("~"))
                throw new ArgumentException("Virtual Path is not in correct form");
            
            _virtualPath = virtualPath;

        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return _handlerFactory.GetHandler(HttpContext.Current, requestContext.HttpContext.Request.HttpMethod,
                                                _virtualPath, requestContext.HttpContext.Server.MapPath(_virtualPath));
            
        }
    }
}