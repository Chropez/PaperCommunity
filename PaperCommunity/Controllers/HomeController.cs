using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperCommunity.Models;
using PaperCommunity.ViewModels;

namespace PaperCommunity.Controllers
{
    public class HomeController : Controller
    {
        private ProEntities db = new ProEntities();

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
