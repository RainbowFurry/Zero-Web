using System.Security.Claims;
using System.Web.Mvc;

namespace Zero_Web.Controllers
{
    public class HomeController : Controller
    {

        //[AllowAnonymous]
        public ActionResult Index()
        {

            //System.Diagnostics.Debug.WriteLine("SomeText");
            //System.Diagnostics.Debug.WriteLine("Message:" + e.Message + "\nSource" + e.Source + "\nData:" + e.Data + "\nStackTrace:" + e.StackTrace + "\n");
            return View();
        }


        //Secure Page Acces with Roles
        [Authorize]//Geht Nicht!
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