using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkateboaringMVCproject.Models;

namespace SkateboaringMVCproject.Controllers
{
    public class SkateboardingsController : Controller
    {
        private SkateboaringMVCprojectContext db = new SkateboaringMVCprojectContext();

        // GET: Skateboardings
        public ActionResult Index()
        {
            var skateboardings = db.Skateboardings.Include(s => s.NameOfTrick);
            return View(skateboardings.ToList());
        }

        // GET: Skateboardings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skateboarding skateboarding = db.Skateboardings.Find(id);
            if (skateboarding == null)
            {
                return HttpNotFound();
            }
            return View(skateboarding);
        }

        // GET: Skateboardings/Create
        public ActionResult Create()
        {
            ViewBag.TrickTypeID = new SelectList(db.TrickTypes, "TrickTypeID", "TrickName");
            return View();
        }

        // POST: Skateboardings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkateboardingID,TimeStart,TimeEnd,Attempts,Landed,TrickTypeID")] Skateboarding skateboarding)
        {
            if (ModelState.IsValid)
            {
                db.Skateboardings.Add(skateboarding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrickTypeID = new SelectList(db.TrickTypes, "TrickTypeID", "TrickName", skateboarding.TrickTypeID);
            return View(skateboarding);
        }

        // GET: Skateboardings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skateboarding skateboarding = db.Skateboardings.Find(id);
            if (skateboarding == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrickTypeID = new SelectList(db.TrickTypes, "TrickTypeID", "TrickName", skateboarding.TrickTypeID);
            return View(skateboarding);
        }

        // POST: Skateboardings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkateboardingID,TimeStart,TimeEnd,Attempts,Landed,TrickTypeID")] Skateboarding skateboarding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skateboarding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrickTypeID = new SelectList(db.TrickTypes, "TrickTypeID", "TrickName", skateboarding.TrickTypeID);
            return View(skateboarding);
        }

        // GET: Skateboardings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skateboarding skateboarding = db.Skateboardings.Find(id);
            if (skateboarding == null)
            {
                return HttpNotFound();
            }
            return View(skateboarding);
        }

        // POST: Skateboardings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skateboarding skateboarding = db.Skateboardings.Find(id);
            db.Skateboardings.Remove(skateboarding);
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
