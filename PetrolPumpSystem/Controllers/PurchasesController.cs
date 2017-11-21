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
    public class PurchasesController : Controller
    {
        private PetrolPumpDBEntities db = new PetrolPumpDBEntities();

        // GET: Purchases
        public ActionResult Index()
        {
            var tblPurchases = db.tblPurchases.Include(t => t.tblProduct).Include(t => t.tblSupplier);
            return View(tblPurchases.ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPurchase tblPurchase = db.tblPurchases.Find(id);
            if (tblPurchase == null)
            {
                return HttpNotFound();
            }
            return View(tblPurchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName");
            ViewBag.SupId = new SelectList(db.tblSuppliers, "SupId", "SupName");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchId,SupId,PId,TankerNo,PurchQuantity,PurchPrice,Unit,PurchDate")] tblPurchase tblPurchase)
        {
            if (ModelState.IsValid)
            {
                db.tblPurchases.Add(tblPurchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName", tblPurchase.PId);
            ViewBag.SupId = new SelectList(db.tblSuppliers, "SupId", "SupName", tblPurchase.SupId);
            return View(tblPurchase);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPurchase tblPurchase = db.tblPurchases.Find(id);
            if (tblPurchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName", tblPurchase.PId);
            ViewBag.SupId = new SelectList(db.tblSuppliers, "SupId", "SupName", tblPurchase.SupId);
            Session["pqty"] = tblPurchase.PurchQuantity;
            return View(tblPurchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchId,SupId,PId,TankerNo,PurchQuantity,PurchPrice,Unit,PurchDate")] tblPurchase tblPurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPurchase).State = EntityState.Modified;
                db.SaveChanges();
                double qtyOnEdit = tblPurchase.PurchQuantity;
                double qtyBeforeEdit = (double)Session["pqty"];
                double qtytotal = qtyOnEdit - qtyBeforeEdit;
                var row = db.tblStocks.FirstOrDefault(x => x.PId == tblPurchase.PId);
                row.StQuantity = (row.StQuantity + qtytotal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PId = new SelectList(db.tblProducts, "PId", "PName", tblPurchase.PId);
            ViewBag.SupId = new SelectList(db.tblSuppliers, "SupId", "SupName", tblPurchase.SupId);
            return View(tblPurchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPurchase tblPurchase = db.tblPurchases.Find(id);
            if (tblPurchase == null)
            {
                return HttpNotFound();
            }
            return View(tblPurchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPurchase tblPurchase = db.tblPurchases.Find(id);
            db.tblPurchases.Remove(tblPurchase);
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
