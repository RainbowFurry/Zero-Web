using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    //[RoutePrefix("{id}")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getStudents")]
        public String getStudents(string id)
        {
            System.Diagnostics.Debug.WriteLine("Test Success!!! + " + id);
            return "";
        }

    }
}