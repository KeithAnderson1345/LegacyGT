using LegacyGT.Models;
using LegacyGT.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LegacyGT.WebMVC.Controllers
{
    [Authorize]
    public class VolunteerController : Controller
    {
        // GET: Volunteer/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VolunteerService(userId);
            var model = service.GetVolunteers();
            return View(model);
        }

        // GET: Create(): Volunteer/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VolunteerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVolunteerService();

            if (service.CreateVolunteer(model))
            {
                TempData["SaveResult"] = "Volunteer was created.";
                return RedirectToAction("Index");
            }


            ModelState.AddModelError("", "Volunteer could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateVolunteerService();
            var model = svc.GetVolunteerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateVolunteerService();
            var detail = service.GetVolunteerById(id);
            var model =
                new VolunteerEdit
                {
                    VolunteerId = detail.VolunteerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,                    
                    ShirtSize = detail.ShirtSize,
                    Dinner = detail.Dinner                    
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VolunteerEdit model)
        {
            if (!ModelState.IsValid) return View();

            if (model.VolunteerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");

                return View(model);
            }

            var service = CreateVolunteerService();

            if (service.UpdateVolunteer(model))
            {
                TempData["SaveResult"] = "Volunteer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Volunteer could not be updated.");

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVolunteerService();
            var model = svc.GetVolunteerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVolunteerService();

            service.DeleteVolunteer(id);

            TempData["SaveResult"] = "Volunteer was deleted.";

            return RedirectToAction("Index");
        }

        private VolunteerService CreateVolunteerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VolunteerService(userId);
            return service;
        }
    }
}