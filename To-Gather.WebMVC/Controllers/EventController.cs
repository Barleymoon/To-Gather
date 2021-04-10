using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Data;
using To_Gather.Models.EventModels;
using To_Gather.Services;

namespace To_Gather.WebMVC.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Event
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            var model = service.GetAllEvents();

            return View(model);
        }

        //GET: 
        // Event/Create
        public ActionResult Create()
        {
            ViewBag.Activities = new SelectList(_db.Activities, "ActivityId", "Title");
            ViewBag.Locations = new SelectList(_db.Locations, "LocationId", "Title");
            return View();
        }

        //POST: 
        //Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["Save Result"] = "This Event has been Created!";
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "This Event could not be created at this time..");
            return View(model);
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
    }
}