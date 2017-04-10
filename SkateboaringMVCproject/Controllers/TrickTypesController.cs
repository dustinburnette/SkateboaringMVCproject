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
    public class TrickTypesController : Controller
    {
        private SkateboaringMVCprojectContext db = new SkateboaringMVCprojectContext();

        // GET: TrickTypes
        public ActionResult Index()
        {
            return View(db.TrickTypes.ToList());
        }

        // GET: TrickTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrickType trickType = db.TrickTypes.Find(id);
            if (trickType == null)
            {
                return HttpNotFound();
            }
            return View(trickType);
        }

        // GET: TrickTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrickTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrickTypeID,TrickName")] TrickType trickType)
        {
            if (ModelState.IsValid)
            {
                db.TrickTypes.Add(trickType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trickType);
        }

        // GET: TrickTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrickType trickType = db.TrickTypes.Find(id);
            if (trickType == null)
            {
                return HttpNotFound();
            }
            return View(trickType);
        }

        // POST: TrickTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrickTypeID,TrickName")] TrickType trickType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trickType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trickType);
        }

        // GET: TrickTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrickType trickType = db.TrickTypes.Find(id);
            if (trickType == null)
            {
                return HttpNotFound();
            }
            return View(trickType);
        }

        // POST: TrickTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrickType trickType = db.TrickTypes.Find(id);
            db.TrickTypes.Remove(trickType);
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
