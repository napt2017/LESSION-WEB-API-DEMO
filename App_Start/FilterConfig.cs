using System.Web;
using System.Web.Mvc;

namespace LESSION_WEB_API_DEMO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
