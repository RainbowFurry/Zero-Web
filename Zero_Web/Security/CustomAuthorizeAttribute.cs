using System.Web.Mvc;
using System.Web.Routing;
using Zero_Web.database;

namespace Zero_Web.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new
                    {
                        controller = "Account",
                        action = "Login"
                    }));
            else
            {
                CustomPrincipal mp = new CustomPrincipal(MongoDBManager.Instance.UserModel.Find(SessionPersister.Username));
                if (!mp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "Error",
                            action = "Forbidden"
                        }));
            }
        }
    }
}