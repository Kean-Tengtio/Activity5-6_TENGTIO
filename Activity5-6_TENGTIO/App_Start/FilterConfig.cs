using System.Web;
using System.Web.Mvc;

namespace Activity5_6_TENGTIO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
