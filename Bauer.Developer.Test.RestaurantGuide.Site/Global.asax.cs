using Bauer.Developer.Test.RestaurantGuide.Site.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bauer.Developer.Test.RestaurantGuide.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string path = Server.MapPath("~/App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        protected void Application_Stop()
        {
        }
    }
}
