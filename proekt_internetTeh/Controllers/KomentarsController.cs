using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using proekt_internetTeh.Models;

namespace proekt_internetTeh.Controllers
{
    public class KomentarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Komentars
        public ActionResult Index(int id)
        {
            var oglas = db.Oglas.Find(id);
            var komentari = db.Komentars.Where(o => o.oglasID == id).ToList();
            ViewBag.KomentarOglas = oglas.zanimanje;
            return View(komentari);
        }
        [ChildActionOnly]
        public ActionResult Pregled(int id)
        {
            var oglas = db.Oglas.Find(id);
            var komentari = db.Komentars.Where(o => o.oglasID == id).ToList();
            ViewBag.KomentarOglas = oglas.zanimanje;
            return PartialView(komentari);
        }
        [Authorize(Roles ="Administrator,Editor,User")]
        public ActionResult Kreiraj(int id)
        {
            Komentar model = new Komentar();
            model.Email = User.Identity.GetUserName();
            model.oglasID = id;
            ViewBag.OglasKomentar = db.Oglas.Find(id).zanimanje;
            return View(model);
        }
        [HttpPost]
        public ActionResult Kreiraj(Komentar model)
        {
            if (!ModelState.IsValid)
            {
                return View("Kreiraj", model);

            }
            db.Komentars.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", new { Id = model.oglasID });
        }
        [ChildActionOnly]
        public ActionResult PartialKreiraj(int id)
        {
            Komentar model = new Komentar();
            model.Email = User.Identity.GetUserName();
            model.oglasID = id;
            ViewBag.OglasKomentar = db.Oglas.Find(id).zanimanje;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult PartialKreiraj(Komentar model)
        {
            db.Komentars.Add(model);
            db.SaveChanges();
            return RedirectToAction("Details", "Oglas", new { Id = model.oglasID });
        }
        // GET: Komentars/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Komentars.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Komentar model)
        {
            if (User.Identity.Name == model.Email)
            {
                var Komentar = db.Komentars.Find(model.Id);
                Komentar.komentar = model.komentar;
                db.SaveChanges();
                //return RedirectToAction("Pregled", new { id = model.oglasID });
                return RedirectToAction("Details", "Oglas", new { Id = model.oglasID });
            }
            return RedirectToAction("NemaPristap", "Oglas");

        }

        public ActionResult Delete(int id)
        {
            Komentar komentar = db.Komentars.Find(id);
            if (User.Identity.Name == komentar.Email)
            {
                var identifikacija = komentar.oglasID;
                db.Komentars.Remove(komentar);
                db.SaveChanges();
                return RedirectToAction("Details", "Oglas", new { Id = identifikacija });
            }
            return RedirectToAction("NemaPristap", "Oglas");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
