using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MBCFM.Models;

namespace MBCFM.Controllers
{
    public class qryOpenCallsController : Controller
    {
        private FMHelpdeskSQLV4Entities db = new FMHelpdeskSQLV4Entities();

        // GET: qryOpenCalls
        public ActionResult Index()
        {
            return View(db.qryOpenCalls.ToList());
        }

        // GET: qryOpenCalls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qryOpenCall qryOpenCall = db.qryOpenCalls.Find(id);
            if (qryOpenCall == null)
            {
                return HttpNotFound();
            }
            return View(qryOpenCall);
        }

        // GET: qryOpenCalls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: qryOpenCalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MBC_Job_No,Client_Job_No,siteName,Priority,OrderType,currentStatus,SubContractor")] qryOpenCall qryOpenCall)
        {
            if (ModelState.IsValid)
            {
                db.qryOpenCalls.Add(qryOpenCall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qryOpenCall);
        }

        // GET: qryOpenCalls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qryOpenCall qryOpenCall = db.qryOpenCalls.Find(id);
            if (qryOpenCall == null)
            {
                return HttpNotFound();
            }
            return View(qryOpenCall);
        }

        // POST: qryOpenCalls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MBC_Job_No,Client_Job_No,siteName,Priority,OrderType,currentStatus,SubContractor")] qryOpenCall qryOpenCall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qryOpenCall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qryOpenCall);
        }

        // GET: qryOpenCalls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qryOpenCall qryOpenCall = db.qryOpenCalls.Find(id);
            if (qryOpenCall == null)
            {
                return HttpNotFound();
            }
            return View(qryOpenCall);
        }

        // POST: qryOpenCalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            qryOpenCall qryOpenCall = db.qryOpenCalls.Find(id);
            db.qryOpenCalls.Remove(qryOpenCall);
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
