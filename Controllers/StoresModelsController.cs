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
    public class StoresModelsController : Controller
    {
        private VRContext db = new VRContext();

        // GET: StoresModels
        public ActionResult Index()
        {
            return View(db.StoresModels.ToList());
        }

        // GET: StoresModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresModels storesModels = db.StoresModels.Find(id);
            if (storesModels == null)
            {
                return HttpNotFound();
            }
            return View(storesModels);
        }

        // GET: StoresModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoresModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreID,StoreName")] StoresModels storesModels)
        {
            if (ModelState.IsValid)
            {
                db.StoresModels.Add(storesModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storesModels);
        }

        // GET: StoresModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresModels storesModels = db.StoresModels.Find(id);
            if (storesModels == null)
            {
                return HttpNotFound();
            }
            return View(storesModels);
        }

        // POST: StoresModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreID,StoreName")] StoresModels storesModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storesModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storesModels);
        }

        // GET: StoresModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresModels storesModels = db.StoresModels.Find(id);
            if (storesModels == null)
            {
                return HttpNotFound();
            }
            return View(storesModels);
        }

        // POST: StoresModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoresModels storesModels = db.StoresModels.Find(id);
            db.StoresModels.Remove(storesModels);
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
