using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chapter4CodeFirst.DAL;
using Chapter4CodeFirst.Models;

namespace Chapter4CodeFirst.Controllers
{
    public class BundlesModelsController : Controller
    {
        private VRContext db = new VRContext();

        // GET: BundlesModels
        public ActionResult Index()
        {
            return View(db.BundlesModels.ToList());
        }

        // GET: BundlesModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BundlesModels bundlesModels = db.BundlesModels.Find(id);
            if (bundlesModels == null)
            {
                return HttpNotFound();
            }
            return View(bundlesModels);
        }

        // GET: BundlesModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BundlesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BundleID,HeadsetBundledID,BundledItem")] BundlesModels bundlesModels)
        {
            if (ModelState.IsValid)
            {
                db.BundlesModels.Add(bundlesModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bundlesModels);
        }

        // GET: BundlesModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BundlesModels bundlesModels = db.BundlesModels.Find(id);
            if (bundlesModels == null)
            {
                return HttpNotFound();
            }
            return View(bundlesModels);
        }

        // POST: BundlesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BundleID,HeadsetBundledID,BundledItem")] BundlesModels bundlesModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bundlesModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bundlesModels);
        }

        // GET: BundlesModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BundlesModels bundlesModels = db.BundlesModels.Find(id);
            if (bundlesModels == null)
            {
                return HttpNotFound();
            }
            return View(bundlesModels);
        }

        // POST: BundlesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BundlesModels bundlesModels = db.BundlesModels.Find(id);
            db.BundlesModels.Remove(bundlesModels);
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
