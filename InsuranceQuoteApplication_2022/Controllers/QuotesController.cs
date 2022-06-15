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
    public class QuotesController : Controller
    {
        private readonly InsuranceQuoteDBEntities _db = new InsuranceQuoteDBEntities();

        // GET: Quotes
        public ActionResult Index()
        {
            var quotes = _db.Quotes.Include(q => q.Insuree);
            return View(quotes.ToList());
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = _db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            ViewBag.InsureeID = new SelectList(_db.Insurees, "InsureeID", "FirstName");
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteNumber,QuoteGenerationDate,InsureeID,BaseRate,AgeUnder18Rate,AgeBetween18And25Rate,AgeOver25Rate,AutoYearBefore2000Rate,AutoYearBetween2000And2015Rate,AutoYearAfter2015Rate,MakeIsPorscheRate,ModelIsCarreraRate,SpeedingTicketRate,SubtotalAfterSpeedingTicketRateCalculation,DUIIncreaseOf25PercentRate,SubtotalAfterDUIRateCalculation,FullCoverageInsuranceRate,QuoteRateTotalAfterCalculation,DiscountRateForPaymentInFull,FinalQuoteYearly_1PaymentDiscountApplied,FinalQuoteMonthly_12PaymentsNoDiscount")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _db.Quotes.Add(quote);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsureeID = new SelectList(_db.Insurees, "InsureeID", "FirstName", quote.InsureeID);
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = _db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsureeID = new SelectList(_db.Insurees, "InsureeID", "FirstName", quote.InsureeID);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteNumber,QuoteGenerationDate,InsureeID,BaseRate,AgeUnder18Rate,AgeBetween18And25Rate,AgeOver25Rate,AutoYearBefore2000Rate,AutoYearBetween2000And2015Rate,AutoYearAfter2015Rate,MakeIsPorscheRate,ModelIsCarreraRate,SpeedingTicketRate,SubtotalAfterSpeedingTicketRateCalculation,DUIIncreaseOf25PercentRate,SubtotalAfterDUIRateCalculation,FullCoverageInsuranceRate,QuoteRateTotalAfterCalculation,DiscountRateForPaymentInFull,FinalQuoteYearly_1PaymentDiscountApplied,FinalQuoteMonthly_12PaymentsNoDiscount")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(quote).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsureeID = new SelectList(_db.Insurees, "InsureeID", "FirstName", quote.InsureeID);
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = _db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = _db.Quotes.Find(id);
            _db.Quotes.Remove(quote);
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
