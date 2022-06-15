using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InsuranceQuoteApplication_2022;
using InsuranceQuoteApplication_2022.Models;

namespace InsuranceQuoteApplication_2022.Controllers
{
    public class InsureesController : Controller
    {
        private readonly InsuranceQuoteDBEntities _db = new InsuranceQuoteDBEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(_db.Insurees.ToList());
        }

        // GET: Insurees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = _db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insurees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsureeID,FirstName,LastName,EmailAddress,DateOfBirth,AutoYear,AutoMake,AutoModel,SpeedingTicket,DUI,FullCoverage")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                _db.Insurees.Add(insuree);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insurees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = _db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insurees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsureeID,FirstName,LastName,EmailAddress,DateOfBirth,AutoYear,AutoMake,AutoModel,SpeedingTicket,DUI,FullCoverage")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(insuree).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insurees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = _db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insurees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = _db.Insurees.Find(id);
            _db.Insurees.Remove(insuree);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
