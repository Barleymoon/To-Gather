using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Data;
using To_Gather.Models.UsersActivityModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class UsersActivityController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: UsersActivity
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UsersActivityService(userId);
            var model = service.GetUsersActivities();

            return View(model);
        }

        public ActionResult Create()
        {
            /*var activities = new SelectList(_db.Activities.ToList(), "ActivityId", "Title");
            ViewBag.Activities = activities;

            var userProfiles = new SelectList(_db.UserProfiles.ToList(), "ProfileId", "UserName");
            ViewBag.UserProfiles = userProfiles;
            return View();*/

            UsersActivityService usersActivityService = CreateUsersActivityService();
            var usersActivities = usersActivityService.GetUsersActivities();
            return View(usersActivities);
        }

        [HttpPost]
        public ActionResult Create(UsersActivityCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            var service = CreateUsersActivityService();

            if (service.CreateUsersActivity(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);

            /*if (ModelState.IsValid)
            {
                Activity activity = _db.Activities.Find(usersActivity.ActivityId);
                if (activity == null) return HttpNotFound("Activity can not be found");

                UserProfile userProfile = _db.UserProfiles.Find(usersActivity.ProfileId);
                if (userProfile == null) return HttpNotFound("UserProfile could not be found");

                _db.UsersActivities.Add(usersActivity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersActivity);*/
        }

        private UsersActivityService CreateUsersActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UsersActivityService(userId);
            return service;
        }
    }
}