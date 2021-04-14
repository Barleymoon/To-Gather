using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Models.UserModels;
using To_Gather.Models.UserProfileModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserProfileService(userId);
            var model = service.GetProfile();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST / UserProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfileCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUserProfileService();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "This Profile was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "User Profile could not be created.");
            return View(model);
        }

        //GET: Details
        public ActionResult Details(int id)
        {
            var src = CreateUserProfileService();
            var model = src.GetProfileById(id);

            return View(model);
        }

        //GET: Edit 
        public ActionResult Edit(int id)
        {
            var service = CreateUserProfileService();
            var detail = service.GetProfileById(id);
            var model =
                new UserProfileEdit
                {
                    ProfileId = detail.ProfileId,
                    UserName = detail.UserName,
                    LastName = detail.LastName,
                    FirstName = detail.FirstName
                };
            return View(model);
        }


        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserProfileEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProfileId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateUserProfileService();

            if (service.UpdateUserProfile(model))
            {
                TempData["SaveResult"] = "This profile has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This profile could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var src = CreateUserProfileService();
            var model = src.GetProfileById(id);

            return View(model);
        }

        //POST: UserProfile/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(int id)
        {
            var service = CreateUserProfileService();

            service.DeleteUser(id);

            TempData["SaveResult"] = "This profile was deleted.";
            return RedirectToAction("Index");
        }

        private UserProfileService CreateUserProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserProfileService(userId);
            return service;
        }
    }
}