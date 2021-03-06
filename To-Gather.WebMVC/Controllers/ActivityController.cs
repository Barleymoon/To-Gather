using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Data;
using To_Gather.Models.ActivityModels;
using To_Gather.Models.UsersActivityModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
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
            // Trying to make drop down list for Activity create
            ViewBag.Categories = new SelectList(_db.Categories, "CategoryId", "Title");
            return View();
        }

        
        //POST: Activity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivityCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateActivityService();

            if (service.CreateActivity(model))
            {
                TempData["SaveResult"] = "This Activity was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "This Activity could not be created..");

            return View(model);
        }

        //GET: Activity/Details/{id}
        public ActionResult Details(int id)
        {
            var src = CreateActivityService();
            var model = src.GetActivityById(id);

            return View(model);
        }

        //GET: Activity/Edit/{id}
        public ActionResult Edit(int id)
        {
            var src = CreateActivityService();
            var newDetail = src.GetActivityById(id);
            var model =
                new ActivityEdit
                {
                    ActivityId = newDetail.ActivityId,
                    Title = newDetail.Title,
                    Description = newDetail.Description,
                    Equipment = newDetail.Equipment,
                    CategoryId = newDetail.CategoryId
                };
            return View(model);
        }

        //POST: Activity/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ActivityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ActivityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateActivityService();

            if (service.UpdateActivity(model))
            {
                TempData["SaveResult"] = "Yay, This activity has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This activity could not be updated, please try again later.");
            return View(model);
        }

        //GET: Activity/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var src = CreateActivityService();
            var model = src.GetActivityById(id);

            return View(model);
        }

        //POST: Activity/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteActivity(int id)
        {
            var src = CreateActivityService();
            
            src.DeleteActivity(id);

            TempData["SaveResult"] = "This activity was deleted";

            return RedirectToAction("Index");
        }


        //GET: Join
        public ActionResult Join()
        {
            return View();
        }


        //POST: Join
        [ActionName("Join")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Join(UsersActivityCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateActivityService();

            if (service.JoinActivityToUsersActivity(model))
            {
                TempData["SaveResult"] = "This activity has been added to your profile.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This activity could not be added to your profile.");
            return View(model);
        }


        //GET: Remove
        [ActionName("Remove")]
        public ActionResult Remove(int id)
        {
            var src = CreateActivityService();
            var model = src.GetUserActivityById(id);
            return View(model);
        }

        //POST: Remove/UserActivity/{id}
        [ActionName("Remove")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUserActivity(int id)
        {
            var src = CreateActivityService();

            src.RemoveUserActivity(id);

            TempData["SaveResult"] = "This activity has been removed from your profile.";

            return RedirectToAction("Index");
        }

        private ActivityService CreateActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ActivityService(userId);
            return service;
        }
    }
}