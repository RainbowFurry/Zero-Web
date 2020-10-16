using System.Security.Claims;
using System.Web.Mvc;
using Zero_Web.Security;

namespace Zero_Web.Controllers
{
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public ActionResult Index()
        {


            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Store");
            }


            //System.Diagnostics.Debug.WriteLine("SomeText");
            //System.Diagnostics.Debug.WriteLine("Message:" + e.Message + "\nSource" + e.Source + "\nData:" + e.Data + "\nStackTrace:" + e.StackTrace + "\n");
        }


        //Secure Page Acces with Roles
        [CustomAuthorize(Roles = "Administrator")]//Geht Nicht!
        //[Authorize(Roles = "Administrator")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var userPrinciple = User as ClaimsPrincipal;

            //Request.GetOwinContext().Authentication.SignOut();

            return View();
        }

        //Secure FileShare
        [HttpPost]
        [ValidateAntiForgeryToken]//Geht NICHT!
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}