using System.Web;
using System.Web.Mvc;

namespace Bauer.Developer.Test.RestaurantGuide.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
