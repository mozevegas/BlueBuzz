using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueBuzz.Models;

namespace BlueBuzz.Controllers
{
    public class EventGenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventGenres
        public ActionResult Index()
        {
            return View(db.EventGenres.ToList());
        }

        // GET: EventGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventGenres eventGenres = db.EventGenres.Find(id);
            if (eventGenres == null)
            {
                return HttpNotFound();
            }
            return View(eventGenres);
        }

        // GET: EventGenres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Genre,VolumeLevel")] EventGenres eventGenres)
        {
            if (ModelState.IsValid)
            {
                db.EventGenres.Add(eventGenres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventGenres);
        }

        // GET: EventGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventGenres eventGenres = db.EventGenres.Find(id);
            if (eventGenres == null)
            {
                return HttpNotFound();
            }
            return View(eventGenres);
        }

        // POST: EventGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Genre,VolumeLevel")] EventGenres eventGenres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventGenres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventGenres);
        }

        // GET: EventGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventGenres eventGenres = db.EventGenres.Find(id);
            if (eventGenres == null)
            {
                return HttpNotFound();
            }
            return View(eventGenres);
        }

        // POST: EventGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventGenres eventGenres = db.EventGenres.Find(id);
            db.EventGenres.Remove(eventGenres);
            db.SaveChanges();
            return RedirectToAction("Index");
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
