using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        //GET: UserActivity/Create
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

        //GET: Details
        //UserActivities/Details/{id}
        public ActionResult Details(int id)
        {
            var src = CreateUserActivityService();
            var model = src.GetUserActivityById(id);

            return View(model);
        }

        //GET: Edit 
        //UserActivity/Edit/{id}
        public ActionResult Edit(int id)
        {
            ViewBag.Activities = new SelectList(_db.Activities, "ActivityId", "Title");
            var src = CreateUserActivityService();
            var newDetail = src.GetUserActivityById(id);
            var model =
                new UserActivityEdit
                {
                    UserActivityId = newDetail.UserActivityId,
                    Title = newDetail.Title,
                    //Activities = newDetail.Activities,
                    ActivityIds = newDetail.ActivityIds
                };
            return View(model);
        }

        //POST: 
        //UserActivity/Edit/{id}
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserActivityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserActivityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateUserActivityService();

            if (service.UpdateUserActivity(model))
            {
                TempData["SaveResult"] = "This Activity was added!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This Activity could not be updated.");
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