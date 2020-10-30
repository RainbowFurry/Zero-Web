using System.Web.Mvc;
using Zero_Web.Models.Store;

namespace Zero_Web.Controllers
{
    public class ProductController : Controller
    {

        public static StoreItem storeItem;

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

    }
}