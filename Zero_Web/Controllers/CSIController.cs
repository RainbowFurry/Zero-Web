using MongoDB.Bson;
using System;
using System.Web.Mvc;
using Zero_Web.Models.Store;

namespace Zero_Web.Controllers
{
    public class CSIController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StoreItem storeItem)
        {
            //Create a Random UID for the User
            storeItem.ID = Guid.NewGuid().ToString();

            //Store Product Data in the DB
            database.MongoDBManager db = new database.MongoDBManager();
            db.createEntry("Product", storeItem.ToBsonDocument());

            //Clear all Registration Fields entered in the View
            ModelState.Clear();

            return View("Index");
        }

        public ActionResult EditStoreItem()
        {
            return View();
        }

    }
}