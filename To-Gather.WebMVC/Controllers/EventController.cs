using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Gather.Data;
using To_Gather.Models.EventModels;
using To_Gather.Models.UserEventModels;
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

        //GET: Details
        public ActionResult Details(int id)
        {
            var src = CreateEventService();
            var model = src.GetEventById(id);

            return View(model);
        }

        //GET: Edit
        //Event/Edit/{id}
        public ActionResult Edit(int id)
        {
            ViewBag.Activities = new SelectList(_db.Activities, "ActivityId", "Title");
            ViewBag.Locations = new SelectList(_db.Locations, "LocationId", "Title");
            var src = CreateEventService();
            var detailNew = src.GetEventById(id);
            var model =
                new EventEdit
                {
                    EventId = detailNew.EventId,
                    Title = detailNew.Title,
                    Description = detailNew.Description,
                    EventTime = detailNew.EventTime,
                    IsOfAge = detailNew.IsOfAge,
                    ActivityId = detailNew.ActivityId,
                    LocationId = detailNew.LocationId
                };
            return View(model);
        }

        //POST: Edit 
        //Event/Edit/{id}
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "This Event has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This Event could not be updated at this time.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var src = CreateEventService();
            var model = src.GetEventById(id);
            return View(model);
        }

        //POST: Delete
        //Event/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int id)
        {
            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "This Event has been deleted.";

            return RedirectToAction("Index");
        }

        //GET: Join
        public ActionResult Join()
        {
            return View();
        }

        //POST: Join
        [HttpPost]
        [ActionName("Join")]
        [ValidateAntiForgeryToken]
        public ActionResult Join(UserEventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.JoinUserEvent(model))
            {
                TempData["SaveResult"] = "This event has been added to your profile.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This event could not be added to your profile.");
            return View(model);
        }

        //GET: Remove
        [ActionName("Remove")]
        public ActionResult Remove(int id)
        {
            var src = CreateEventService();
            var model = src.GetUserEventById(id);
            return View(model);
        }

        //POST: Remove
        [HttpPost]
        [ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUserEvent(int id)
        {
            var src = CreateEventService();

            src.RemoveUserEvent(id);

            TempData["SaveResult"] = "This Event was removed from your profile.";
            
            return RedirectToAction("Index");
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
    }
}