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
using PagedList;
using PagedList.Mvc;
namespace Chapter4CodeFirst.Controllers
{
    public class VRHeadsetModelsController : Controller
    {
        private VRContext db = new VRContext();

        // GET: VRHeadsetModels
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var vrheadset = from s in db.VRHeadsetModels
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vrheadset = vrheadset.Where(s => s.HeadsetName.Contains(searchString) || s.AvailableStoreName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vrheadset = vrheadset.OrderByDescending(s => s.HeadsetName);
                    break;
                case "Date":
                    vrheadset = vrheadset.OrderBy(s => s.AvailableStoreName);
                    break;
                case "date_desc":
                    vrheadset = vrheadset.OrderByDescending(s => s.AvailableStoreName);
                    break;
                default:
                    vrheadset = vrheadset.OrderBy(s => s.HeadsetName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(vrheadset.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult EditDisplay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VRHeadsetModels vRHeadsetModels = db.VRHeadsetModels.Find(id);
            if (vRHeadsetModels == null)
            {
                return HttpNotFound();
            }
            return View(vRHeadsetModels);
        }

        // POST: VRHeadsetModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDisplay([Bind(Include = "HeadsetID,Price,AvailableStoreName,HeadsetName")] VRHeadsetModels vRHeadsetModels)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(vRHeadsetModels).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("","Unable to save changes. Try again, if the problem persists please contact your systems administrator.");
            }
            return View(vRHeadsetModels);
        }
        
        public ActionResult Display()
        {
            return View(db.VRHeadsetModels.ToList());
        }

        // GET: VRHeadsetModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VRHeadsetModels vRHeadsetModels = db.VRHeadsetModels.Find(id);
            if (vRHeadsetModels == null)
            {
                return HttpNotFound();
            }
            return View(vRHeadsetModels);
        }

        // GET: VRHeadsetModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VRHeadsetModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeadsetID,Price,AvailableStoreName,HeadsetName")] VRHeadsetModels vRHeadsetModels)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.VRHeadsetModels.Add(vRHeadsetModels);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, if the problem persists please contact your systems administrator.");

            }

            return View(vRHeadsetModels);
        }

        // GET: VRHeadsetModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VRHeadsetModels vRHeadsetModels = db.VRHeadsetModels.Find(id);
            if (vRHeadsetModels == null)
            {
                return HttpNotFound();
            }
            return View(vRHeadsetModels);
        }

        // POST: VRHeadsetModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeadsetID,Price,AvailableStoreName,HeadsetName")] VRHeadsetModels vRHeadsetModels)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(vRHeadsetModels).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException) {
                    ModelState.AddModelError("", "Unable to save changes. Try again, if the problem persists please contact your systems administrator.");
                }
            }
            return View(vRHeadsetModels);
        }

        // GET: VRHeadsetModels/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ModelState.AddModelError("", "Delete Failed. Try again, if the problem persists please contact your systems administrator.");
            }
            VRHeadsetModels vRHeadsetModels = db.VRHeadsetModels.Find(id);
            if (vRHeadsetModels == null)
            {
                return HttpNotFound();
            }
            return View(vRHeadsetModels);
        }

        // POST: VRHeadsetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            { 
                VRHeadsetModels vRHeadsetModels = db.VRHeadsetModels.Find(id);
                db.VRHeadsetModels.Remove(vRHeadsetModels);
                db.SaveChanges();
            return RedirectToAction("Index");

            }
            catch (DataException)
            {
            return RedirectToAction("Delete", new { id = id, saveChangesError = true});
            }
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
