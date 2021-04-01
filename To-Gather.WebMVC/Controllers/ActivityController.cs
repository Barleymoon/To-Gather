using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Models.ActivityModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ActivityService(userId);
            var model = service.GetAllActivities();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST: Activity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivityCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateActivityService();

            if (service.CreateActivity(model))
            {
                ViewBag["SaveResult"] = "This Activity was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "This Activity could not be created..");

            return View(model);
        }

        private ActivityService CreateActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ActivityService(userId);
            return service;
        }
    }
}