using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Models.UserActivityModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class UserActivityController : Controller
    {
        // GET: UserActivity
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserActivityService(userId);
            var model = service.GetActivitiesByOwner();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
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

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserActivityService(userId);

            service.CreateUserActivity(model);

            return RedirectToAction("Index");
        }
    }
}