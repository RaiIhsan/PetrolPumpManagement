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
    public class CompanyInfoesController : Controller
    {
        private PetrolPumpDBEntities db = new PetrolPumpDBEntities();

        // GET: CompanyInfoes
        public ActionResult Index()
        {

            return View(db.tblCompanyInfoes.ToList());
        }

        // GET: CompanyInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompanyInfo tblCompanyInfo = db.tblCompanyInfoes.Find(id);
            if (tblCompanyInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblCompanyInfo);
        }

        // GET: CompanyInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompId,CompName,CompMobile,CompPhone,CompAddress,CompLogo")] tblCompanyInfo tblCompanyInfo)
        {
            if (ModelState.IsValid)
            {
                db.tblCompanyInfoes.Add(tblCompanyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCompanyInfo);
        }

        // GET: CompanyInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompanyInfo tblCompanyInfo = db.tblCompanyInfoes.Find(id);
            if (tblCompanyInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblCompanyInfo);
        }

        // POST: CompanyInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompId,CompName,CompMobile,CompPhone,CompAddress,CompLogo")] tblCompanyInfo tblCompanyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCompanyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCompanyInfo);
        }

        // GET: CompanyInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompanyInfo tblCompanyInfo = db.tblCompanyInfoes.Find(id);
            if (tblCompanyInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblCompanyInfo);
        }

        // POST: CompanyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCompanyInfo tblCompanyInfo = db.tblCompanyInfoes.Find(id);
            db.tblCompanyInfoes.Remove(tblCompanyInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dashboard()
        {
            Session["totalfuels"] = db.tblProducts.Count();
            Session["totalSuppliers"] = db.tblSuppliers.Count();

            return View();
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
