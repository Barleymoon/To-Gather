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
            UsersActivityService usersActivityService = CreateUsersActivityService();
            var usersActivities = usersActivityService.GetUsersActivities();
            return View(usersActivities);
        }

        [HttpPost]
        //[ActionName("Join")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersActivityCreate model)
        {
            if (!ModelState.IsValid) return View(ModelState);

            var service = CreateUsersActivityService();

            if (service.CreateUsersActivity(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private UsersActivityService CreateUsersActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UsersActivityService(userId);
            return service;
        }
    }
}