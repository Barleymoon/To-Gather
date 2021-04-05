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
            
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserProfileService(userId);

            service.CreateUser(model);

            return RedirectToAction("Index");
        }
    }
}