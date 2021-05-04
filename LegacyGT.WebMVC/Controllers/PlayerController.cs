using LegacyGT.Data;
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
    public class PlayerController : Controller
    {
        // GET: Player/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService(userId);
            var model = service.GetPlayers();
            return View(model);
        }

        // GET: Create(): Player/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlayerService();
            

            if (service.CreatePlayer(model))
            {
                //var dinnerService = CreateDinnerService();
                //dinnerService.CreatePlayerDinner(model);
                TempData["SaveResult"] = "Player was created.";                
                return RedirectToAction("Index");
            }




            ModelState.AddModelError("", "Player could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlayerService();
            var detail = service.GetPlayerById(id);
            var model =
                new PlayerEdit
                {
                    PlayerId = detail.PlayerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    Handicap = detail.Handicap,
                    ShirtSize = detail.ShirtSize,
                    Dinner = detail.Dinner,
                    Raffle = detail.Raffle,
                    Mulligans = detail.Mulligans
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayerEdit model)
        {
            if (!ModelState.IsValid) return View();

            if (model.PlayerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");

                return View(model);
            }

            var service = CreatePlayerService();

            if (service.UpdatePlayer(model))
            {
                TempData["SaveResult"] = "Player was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Player could not be updated.");

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlayerService();

            service.DeletePlayer(id);

            TempData["SaveResult"] = "Player was deleted.";

            return RedirectToAction("Index");
        }

        private PlayerService CreatePlayerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService(userId);
            return service;
        }

        public DinnerService CreateDinnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dinnerService = new DinnerService(userId);
            return dinnerService;
        }
    }
}