﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperCommunity.Models;
using PaperCommunity.BusinessLogic;

namespace PaperCommunity.Controllers
{
    public class GameController : Controller
    {
        private ProEntities db = new ProEntities();

        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        //
        // GET: /Game/Details/5

        public ActionResult Details(int id = 0)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //
        // GET: /Game/Create

        public ActionResult Create()
        {
            GamingSessionService GamingSessionService = new GamingSessionService();
            ViewBag.PlayerHomeTeamList = GamingSessionService.getPlayerTeamSelectList(Game.HOME);
            ViewBag.PlayerAwayTeamList = GamingSessionService.getPlayerTeamSelectList(Game.AWAY);

            Game defaultGame = new Game();
            defaultGame.HomeGoals = 0;
            defaultGame.AwayGoals = 0;

            return View(defaultGame);
        }

        //
        // POST: /Game/Create

        [HttpPost]
        public ActionResult Create(Game game)
        {

            
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            GamingSessionService GamingSessionService = new GamingSessionService();

            return View(game);
        }

        //
        // GET: /Game/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //
        // POST: /Game/Edit/5

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        //
        // GET: /Game/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //
        // POST: /Game/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}