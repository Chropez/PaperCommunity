using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperCommunity.Models;
using PaperCommunity.ViewModels;


namespace PaperCommunity.Controllers
{
    public class PlayerController : Controller
    {
        private ProEntities db = new ProEntities();

        //
        // GET: /Player/

        public ActionResult Index()
        {
            return View(db.Players.ToList());
        }

        //
        // GET: /Player/Details/5

        public ActionResult Details(string id = "")
        {
            Player player = db.Players.Find(id);

            if (player == null)
            {
                return HttpNotFound();
            }

            Statistic st = new Statistic();

            PlayerDetailsViewModel ViewModel = new PlayerDetailsViewModel();
            ViewModel.Player = player;
            ViewModel.OverallPlayerData = st.getOverallPlayerData(player);

            return View(ViewModel);
        }

        //
        // GET: /Player/Create

        public ActionResult Create()
        {
            ViewBag.Teams = new SelectList(db.Teams, "Name", "Name");
            return View();
        }

        //
        // POST: /Player/Create

        [HttpPost]
        public ActionResult Create(Player player)
        {
            player.DefaultTeam = db.Teams.Find(player.DefaultTeam.Name);

            if (ModelState.IsValid)
            {   
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teams = new SelectList(db.Teams, "Name", "Name");
            return View(player);
        }

        //
        // GET: /Player/Edit/5

        public ActionResult Edit(string id = "")
        {

            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            ViewBag.Teams = new SelectList(db.Teams, "Name", "Name");
            return View(player);
        }

        //
        // POST: /Player/Edit/5

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teams = new SelectList(db.Teams, "Name", "Name");
            return View(player);
        }

        //
        // GET: /Player/Delete/5

        public ActionResult Delete(string id = "")
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Player/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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