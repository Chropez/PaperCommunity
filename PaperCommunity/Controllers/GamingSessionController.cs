using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperCommunity.Models;
using PaperCommunity.ViewModels;
using PaperCommunity.BusinessLogic;
using System.Data.Entity.Infrastructure;

namespace PaperCommunity.Controllers
{
    public class GamingSessionController : Controller
    {
        private ProEntities db = new ProEntities();

        //
        // GET: /GaminSession/

        public ActionResult Index()
        {
            return View(db.GamingSessions.ToList());
        }

        
        //
        // GET: /GaminSession/Details/5

        public ActionResult Details(int id = 0)
        {
            GamingSession gamingsession = db.GamingSessions.Find(id);
            if (gamingsession == null)
            {
                return HttpNotFound();
            }
            return View(gamingsession);
        }

        //
        // GET: /GaminSession/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GaminSession/Create

        [HttpPost]
        public ActionResult Create(GamingSession GamingSession)
        {

            if (GamingSession.Date == null) GamingSession.Date = DateTime.Today;

            if (ModelState.IsValid)
            {
                db.GamingSessions.Add(GamingSession);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View(GamingSession);

            
            
            
            /*

            Match NewMatch = GamingSessionViewModel.NewMatch;


            if (ModelState.IsValid)
            {
                //Create new TeamPlayer combination
                Player HomePlayer = GamingSessionViewModel.HomePlayer;
                Team HomeTeam = GamingSessionViewModel.HomeTeam;
                PlayerTeam HomePlayerTeam = new PlayerTeam().getPlayerTeam(HomePlayer, HomeTeam);
                //if (HomePlayerTeam.id == null)
                //{
                //    db.PlayerTeams.Add(HomePlayerTeam);    
                //}

                Player AwayPlayer = GamingSessionViewModel.AwayPlayer;
                Team AwayTeam = GamingSessionViewModel.AwayTeam;
                PlayerTeam AwayPlayerTeam = new PlayerTeam().getPlayerTeam(AwayPlayer, AwayTeam);
                //if (AwayPlayerTeam.id == null)
                //{
                //    db.PlayerTeams.Add(AwayPlayerTeam);
                //}

                GamingSession thisSession = GamingSessionViewModel.GamingSession;
                if (thisSession.id == -1)
                {
                    //thisSession.Date = DateTime.Now;
                    //db.GamingSessions.Add(thisSession);
                }
                else
                {
                    thisSession = db.GamingSessions.Where(g => g.id == thisSession.id).First();
                }



                db.GamingSessions.Add(thisSession);
                db.SaveChanges();

                return RedirectToAction("Index");
            }*/

        }

        //
        // GET: /GaminSession/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GamingSession GamingSession = db.GamingSessions.Find(id);
            GamingSessionViewModel GamingSessionViewModel = new GamingSessionViewModel();
            GamingSessionViewModel.GamingSession = GamingSession;

            GamingSessionService GamingSessionService = new GamingSessionService();

            if (GamingSession == null)
            {
                return HttpNotFound();
            }

            //Add viewbags

            return View(GamingSessionViewModel);
        }

        //
        // POST: /GaminSession/Edit/5

        [HttpPost]
        public ActionResult Edit(GamingSessionViewModel GamingSessionViewModel)
        {





            if (ModelState.IsValid)
            {
                //Adds the new Game

                GamingSession GamingSession = db.GamingSessions.Find(GamingSessionViewModel.GamingSession.id);
                Game NewGame = GamingSessionViewModel.NewGame;

                //Home Team

                Team HomeTeamTeam = db.pushTeam(NewGame.HomeTeam);
                NewGame.HomeTeam = HomeTeamTeam;

                NewGame.HomePlayer.DefaultTeam = HomeTeamTeam;
                Player HomeTeamPlayer = db.pushPlayer(NewGame.HomePlayer);
                NewGame.HomePlayer = HomeTeamPlayer;

                //Away Team
                Team AwayTeamTeam = db.pushTeam(NewGame.AwayTeam);
                NewGame.AwayTeam = AwayTeamTeam;

                NewGame.AwayPlayer.DefaultTeam = AwayTeamTeam;
                Player AwayTeamPlayer = db.pushPlayer(NewGame.AwayPlayer);
                NewGame.AwayPlayer = AwayTeamPlayer;

                
                //New Game
                GamingSession.Games.Add(GamingSessionViewModel.NewGame);
                
                //Other attributes
                GamingSession.Date = GamingSessionViewModel.GamingSession.Date;


                //db.GamingSessions.Attach(GamingSessionViewModel.GamingSession);
                
                //db.Entry(GamingSessionViewModel.GamingSession).State = EntityState.Modified;
                db.Games.Add(NewGame);

                var state = db.Entry(GamingSession).State;
                var state2 = db.Entry(NewGame).State;

                db.Entry(GamingSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(GamingSessionViewModel);
        }

        //
        // GET: /GaminSession/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GamingSession gamingsession = db.GamingSessions.Find(id);
            if (gamingsession == null)
            {
                return HttpNotFound();
            }
            return View(gamingsession);
        }

        //
        // POST: /GaminSession/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GamingSession gamingsession = db.GamingSessions.Find(id);
            db.GamingSessions.Remove(gamingsession);
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