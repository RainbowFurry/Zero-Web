using System.Web.Mvc;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}