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
    public class OglasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Oglas
        public ActionResult Index()
        {
            return View(db.Oglas.ToList());
        }
        // GET: Oglas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.Oglas.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // GET: Oglas/Create
        [Authorize(Roles="Administrator,Editor,User")]
        public ActionResult Create()
        {
            Oglas model = new Oglas();
            model.email = User.Identity.GetUserName();
            return View(model);
        }

        // POST: Oglas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,zanimanje,kategorija,pocetnaData,krajnaData,pravnoLice,opstina,adresa,email,telBroj,slikaUrl,opis, cena, urlSlika2")] Oglas oglas)
        {
            if (ModelState.IsValid)
            {
                db.Oglas.Add(oglas);
                db.SaveChanges();
                return RedirectToAction("OglasToKategorija",new {Id=oglas.Id});
            }

            return View(oglas);
        }
        [Authorize(Roles = "Administrator,Editor,User")]
        public ActionResult OglasToKategorija(int id)
        {
            OglasToCategoryModel model = new OglasToCategoryModel();
            model.selectedOglas = id;
            ViewBag.imeOglas = db.Oglas.Find(model.selectedOglas).zanimanje;
            model.categories = db.Categories.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult OglasToKategorija(OglasToCategoryModel model)
        {
            var kategorija = db.Categories.Find(model.selectedCategory);
            var oglas = db.Oglas.Find(model.selectedOglas);
            kategorija.Oglasi.Add(oglas);
            oglas.kategorija = kategorija;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Oglas/Edit/5
        [Authorize(Roles = "Administrator,Editor,User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.Oglas.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // POST: Oglas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,zanimanje,kategorija,pocetnaData,krajnaData,pravnoLice,opstina,adresa,email,telBroj,slikaUrl,opis, cena, urlSlika2")] Oglas oglas)
        {
            if (User.Identity.Name == oglas.email || User.IsInRole("Editor"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(oglas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("OglasToKategorija", new { Id = oglas.Id });
                }
                return View(oglas);
            }
            return RedirectToAction("NemaPristap");
        }

        // GET: Oglas/Delete/5
        [Authorize(Roles = "Administrator,Editor,User")]
        public ActionResult Delete(int id)
        {
            Oglas oglas = db.Oglas.Find(id);

            if (User.Identity.Name == oglas.email || User.IsInRole("Editor"))
            {
                db.Oglas.Remove(oglas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("NemaPristap");
        }
        public ActionResult NemaPristap()
        {
            return View();
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
