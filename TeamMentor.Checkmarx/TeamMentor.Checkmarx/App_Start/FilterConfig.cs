using System.Web;
using System.Web.Mvc;

namespace TeamMentor.Checkmarx
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}