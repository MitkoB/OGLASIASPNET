using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proekt_internetTeh.Models;

namespace proekt_internetTeh.Controllers
{
    public class RatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles ="Administrator,Editor,User")]
        public ActionResult Postavi(int id)
        {
            Rating model = new Rating();
            Oglas oglas = db.Oglas.Find(id);
            model.email = User.Identity.Name;
            model.oglas = id;
            ViewBag.Ime = oglas.zanimanje;
            model.ratings.Add(1);
            model.ratings.Add(2);
            model.ratings.Add(3);
            model.ratings.Add(4);
            model.ratings.Add(5);
            return View(model);
        }
        [HttpPost]
        public ActionResult Postavi(Rating model)
        {
            int identifikator = model.oglas;
            var oglas = db.Oglas.Find(identifikator);
            oglas.rejtinzi.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Oglas");
        }
    }
}
