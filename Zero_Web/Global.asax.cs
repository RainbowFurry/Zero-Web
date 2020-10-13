using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Zero_Web
{
   public class MvcApplication : HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);

         //Create MongoDB Connection
         //MongoDBManager db = new MongoDBManager();
         //db.createConnection();

      }
   }
}
