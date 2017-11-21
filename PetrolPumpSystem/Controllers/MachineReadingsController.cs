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
    public class MachineReadingsController : Controller
    {
        private PetrolPumpDBEntities db = new PetrolPumpDBEntities();

        // GET: MachineReadings
        public ActionResult Index()
        {
            var tblMachineReadings = db.tblMachineReadings.Include(t => t.Machine);
            return View(tblMachineReadings.ToList());
        }

        // GET: MachineReadings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMachineReading tblMachineReading = db.tblMachineReadings.Find(id);
            if (tblMachineReading == null)
            {
                return HttpNotFound();
            }
            return View(tblMachineReading);
        }

        // GET: MachineReadings/Create
        public ActionResult Create()
        {
            ViewBag.MachineId = new SelectList(db.Machines, "MachinId", "MachineName");
            return View();
        }

        // POST: MachineReadings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MReadingId,StartReading,EndingReading,ReadingDate,MachineId")] tblMachineReading tblMachineReading)
        {
            if (ModelState.IsValid)
            {
                db.tblMachineReadings.Add(tblMachineReading);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MachineId = new SelectList(db.Machines, "MachinId", "MachineName", tblMachineReading.MachineId);
            return View(tblMachineReading);
        }

        // GET: MachineReadings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMachineReading tblMachineReading = db.tblMachineReadings.Find(id);
            if (tblMachineReading == null)
            {
                return HttpNotFound();
            }
            ViewBag.MachineId = new SelectList(db.Machines, "MachinId", "MachineName", tblMachineReading.MachineId);
            return View(tblMachineReading);
        }

        // POST: MachineReadings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MReadingId,StartReading,EndingReading,ReadingDate,MachineId")] tblMachineReading tblMachineReading)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMachineReading).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MachineId = new SelectList(db.Machines, "MachinId", "MachineName", tblMachineReading.MachineId);
            return View(tblMachineReading);
        }

        // GET: MachineReadings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMachineReading tblMachineReading = db.tblMachineReadings.Find(id);
            if (tblMachineReading == null)
            {
                return HttpNotFound();
            }
            return View(tblMachineReading);
        }

        // POST: MachineReadings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMachineReading tblMachineReading = db.tblMachineReadings.Find(id);
            db.tblMachineReadings.Remove(tblMachineReading);
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
