using System.Collections;
using System.Web.Mvc;

namespace Zero_Web.Controllers
{
    public class StoreController : Controller
    {

        private static ArrayList alreadyShown;

        public ActionResult Index()
        {
            alreadyShown = new ArrayList();
            return View();
        }

        public ActionResult Free()
        {
            return View();
        }

        public ActionResult Charts()
        {
            return View();
        }

        public ActionResult Sale()
        {
            return View();
        }

        public ActionResult ZeroPlus()
        {
            return View();
        }

        public static ArrayList GetAlreadyShown()
        {
            return alreadyShown;
        }

    }
}