using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Data;
using To_Gather.Models.UserActivityModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class UserActivityController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: UserActivity
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserActivityService(userId);
            var model = service.GetAllUserActivities();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            ViewBag.Activities = new SelectList(_db.Activities, "ActivityId", "Title");
            return View();
        }

        //POST: UserActivity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserActivityCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserActivityService service = CreateUserActivityService();

            if (service.CreateUserActivity(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private UserActivityService CreateUserActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserActivityService(userId);
            return service;
        }
    }
}