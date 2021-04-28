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
    public class SponsorController : Controller
    {
        // GET: Sponsor/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SponsorService(userId);
            var model = service.GetSponsors();
            return View(model);
        }

        // GET: Create(): Sponsor/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SponsorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSponsorService();

            if (service.CreateSponsor(model))
            {
                TempData["SaveResult"] = "Sponsor was created.";
                return RedirectToAction("Index");
            }


            ModelState.AddModelError("", "Sponsor could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSponsorService();
            var model = svc.GetSponsorById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSponsorService();
            var detail = service.GetSponsorById(id);
            var model =
                new SponsorEdit
                {
                    SponsorId = detail.SponsorId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email                    
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SponsorEdit model)
        {
            if (!ModelState.IsValid) return View();

            if (model.SponsorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");

                return View(model);
            }

            var service = CreateSponsorService();

            if (service.UpdateSponsor(model))
            {
                TempData["SaveResult"] = "Sponsor was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sponsor could not be updated.");

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSponsorService();
            var model = svc.GetSponsorById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSponsorService();

            service.DeleteSponsor(id);

            TempData["SaveResult"] = "Sponsor was deleted.";

            return RedirectToAction("Index");
        }

        private SponsorService CreateSponsorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SponsorService(userId);
            return service;
        }
    }
}