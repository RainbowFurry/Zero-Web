using System.Collections;
using System.Web.Mvc;
using Zero_Web.database;

namespace Zero_Web.Controllers
{
    public class StoreController : Controller
    {

        private static ArrayList alreadyShown;

        private static ArrayList content;

        public ActionResult Index()
        {
            alreadyShown = new ArrayList();
            content = new ArrayList(MongoDBManager.Instance.GetAllStoreItems());
            return View();
        }

        public ActionResult Free()
        {
            alreadyShown = new ArrayList();
            content = MongoDBManager.Instance.GetFreeStoreItems();
            return View();
        }

        public ActionResult Charts()
        {
            if (content != null)
                content.Clear();
            alreadyShown = new ArrayList();
            content = new ArrayList(MongoDBManager.Instance.GetAllStoreItems());
            return View();
        }

        public ActionResult Sale()
        {
            alreadyShown = new ArrayList();
            content = MongoDBManager.Instance.GetSaleStoreItems();
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

        public static ArrayList GetContent()
        {
            return content;
        }
    }
}