using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Data;
using To_Gather.Models.UserEventModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class UserEventController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: UserEvent
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserEventService(userId);
            var model = service.GetAllUsersEvent();

            return View(model);
        }

        public ActionResult Join()
        {
            UserEventService userEventService = CreateUserEventService();
            var eventService = userEventService.GetAllUsersEvent();
            return View(eventService);
        }

        [HttpPost]
        [ActionName("Join")]
        [ValidateAntiForgeryToken]
        public ActionResult Join(UserEventCreate model)
        {
            if (!ModelState.IsValid) return View(ModelState);

            var service = CreateUserEventService();

            if (service.CreateUserEvent(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public UserEventService CreateUserEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserEventService(userId);
            return service;
        }
    }
}