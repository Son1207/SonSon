using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TranHoaiSon_19DH110901_Lab4_LTWNC.Models;

namespace TranHoaiSon_19DH110901_Lab4_LTWNC.Controllers
{
    public class ITEMSController : Controller
    {
        private SalesEntities db = new SalesEntities();

        // GET: ITEMS
        public ActionResult Index()
        {
            var iTEMs = db.ITEMs.Include(i => i.CATEGORY);
            return View(iTEMs.ToList());
        }

        // GET: ITEMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEMs.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // GET: ITEMS/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.CATEGORies, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ITEMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemName,CategoryId,ItemPrice,ItemImageName")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.ITEMs.Add(iTEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.CATEGORies, "CategoryId", "CategoryName", iTEM.CategoryId);
            return View(iTEM);
        }

        // GET: ITEMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEMs.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.CATEGORies, "CategoryId", "CategoryName", iTEM.CategoryId);
            return View(iTEM);
        }

        // POST: ITEMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemName,CategoryId,ItemPrice,ItemImageName")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CATEGORies, "CategoryId", "CategoryName", iTEM.CategoryId);
            return View(iTEM);
        }

        // GET: ITEMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEMs.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // POST: ITEMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEM iTEM = db.ITEMs.Find(id);
            db.ITEMs.Remove(iTEM);
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
