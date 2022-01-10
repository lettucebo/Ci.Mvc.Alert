using System.Web;
using System.Web.Mvc;

namespace Ci.Mvc.Alert.Net.Example
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
