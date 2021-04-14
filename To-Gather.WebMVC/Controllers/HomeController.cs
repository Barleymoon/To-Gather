using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace To_Gather.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Learn more about this App and who made it.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to Contact.";

            return View();
        }
    }
}