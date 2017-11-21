using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetrolPumpSystem.Models;

namespace PetrolPumpSystem.Controllers
{
    public class StocksController : Controller
    {
        private PetrolPumpDBEntities db = new PetrolPumpDBEntities();

        // GET: tblStocks
        public ActionResult Index()
        {
            var tblStocks = db.tblStocks.Include(t => t.tblProduct);
            return View(tblStocks.ToList());
        }

        // GET: tblStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStock tblStock = db.tblStocks.Find(id);
            if (tblStock == null)
            {
                return HttpNotFound();
            }
            return View(tblStock);
        }

        // GET: tblStocks/Create
        public ActionResult Create()
        {
            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName");
            return View();
        }

        // POST: tblStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StId,PId,StQuantity,StRate,StDate")] tblStock tblStock)
        {
            if (ModelState.IsValid)
            {
                db.tblStocks.Add(tblStock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName", tblStock.PId);
            return View(tblStock);
        }

        // GET: tblStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStock tblStock = db.tblStocks.Find(id);
            if (tblStock == null)
            {
                return HttpNotFound();
            }
            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName", tblStock.PId);
            return View(tblStock);
        }

        // POST: tblStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StId,PId,StQuantity,StRate,StDate")] tblStock tblStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName", tblStock.PId);
            return View(tblStock);
        }

        // GET: tblStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStock tblStock = db.tblStocks.Find(id);
            if (tblStock == null)
            {
                return HttpNotFound();
            }
            return View(tblStock);
        }

        // POST: tblStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStock tblStock = db.tblStocks.Find(id);
            db.tblStocks.Remove(tblStock);
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
