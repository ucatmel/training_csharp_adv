using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HalloWeb.Models;

namespace HalloWeb.Controllers
{
    public class StiftController : Controller
    {
        private HalloWebContext db = new HalloWebContext();

        // GET: Stift
        public ActionResult Index()
        {
            return View(db.Stifts.ToList());
        }

        // GET: Stift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stift stift = db.Stifts.Find(id);
            if (stift == null)
            {
                return HttpNotFound();
            }
            return View(stift);
        }

        // GET: Stift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Farbe,Staerke,IstWasserfest")] Stift stift)
        {
            if (ModelState.IsValid)
            {
                db.Stifts.Add(stift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stift);
        }

        // GET: Stift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stift stift = db.Stifts.Find(id);
            if (stift == null)
            {
                return HttpNotFound();
            }
            return View(stift);
        }

        // POST: Stift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Farbe,Staerke,IstWasserfest")] Stift stift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stift);
        }

        // GET: Stift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stift stift = db.Stifts.Find(id);
            if (stift == null)
            {
                return HttpNotFound();
            }
            return View(stift);
        }

        // POST: Stift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stift stift = db.Stifts.Find(id);
            db.Stifts.Remove(stift);
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
