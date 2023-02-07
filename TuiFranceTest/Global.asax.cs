using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TuiFranceTest.Dal;

namespace TuiFranceTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();

            Database.SetInitializer<TuiFranceTestContext>(new TuiFranceTestDBInitializer());

            using (var context = new TuiFranceTestContext())
            {
                context.Database.Initialize(force: true);
            }

        }
    }
}
