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
    public class FMIncidentsFM261Controller : Controller
    {
        private FMHelpdeskSQLV4Entities db = new FMHelpdeskSQLV4Entities();

        // GET: FMIncidentsFM261
        public ActionResult Index()
        {
            return View(db.FMIncidentsFM261.ToList());
        }

        // GET: FMIncidentsFM261/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMIncidentsFM261 fMIncidentsFM261 = db.FMIncidentsFM261.Find(id);
            if (fMIncidentsFM261 == null)
            {
                return HttpNotFound();
            }
            return View(fMIncidentsFM261);
        }

        // GET: FMIncidentsFM261/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FMIncidentsFM261/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MBC_Job_No,Client_Job_No,SiteNo,OrderType,Trade,EnteredBy,Date,ReportedBy,SiteTelNo,DateOpened,Priority,ResponseTime,RequiredBy,DateClosed,SubContractor,Note,AddNewNotes,Problem,todaysDate,timeOnSite,timeOffSite,materials,labour,totalCost,currentStatus,costingNotes,subContractorMaterials,subContractorlabour,subContractorcosts,subContractorOverheads,subContractorProfit,subContractorTotal,siteName,siteAddress,siteAddress2,siteStreet,siteTown,siteCounty,sitePostCode,Invoiced,jobLimits,estimatedTimeOfCompletion,UpliftApprovedBy,totalTimeOnSite,overHeads,materialsProfit,profitOnPlant,jobSheetSigned,callOutRate,initialCallOut,callOutFee,totalToInvoice,siteAllocation,subContractorInvoiceNumber,subContractorInvoiceDate,subContractorInvoicePaid,quotationDated,quotationApprovedDate,timeOnSite2,timeOffSite2,timeOnSite3,timeOffSite3,timeOnSite4,timeOffSite4,siteNotes,addSiteNotes,TimeStamp")] FMIncidentsFM261 fMIncidentsFM261)
        {
            if (ModelState.IsValid)
            {
                db.FMIncidentsFM261.Add(fMIncidentsFM261);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fMIncidentsFM261);
        }

        // GET: FMIncidentsFM261/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMIncidentsFM261 fMIncidentsFM261 = db.FMIncidentsFM261.Find(id);
            if (fMIncidentsFM261 == null)
            {
                return HttpNotFound();
            }
            return View(fMIncidentsFM261);
        }

        // POST: FMIncidentsFM261/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MBC_Job_No,Client_Job_No,SiteNo,OrderType,Trade,EnteredBy,Date,ReportedBy,SiteTelNo,DateOpened,Priority,ResponseTime,RequiredBy,DateClosed,SubContractor,Note,AddNewNotes,Problem,todaysDate,timeOnSite,timeOffSite,materials,labour,totalCost,currentStatus,costingNotes,subContractorMaterials,subContractorlabour,subContractorcosts,subContractorOverheads,subContractorProfit,subContractorTotal,siteName,siteAddress,siteAddress2,siteStreet,siteTown,siteCounty,sitePostCode,Invoiced,jobLimits,estimatedTimeOfCompletion,UpliftApprovedBy,totalTimeOnSite,overHeads,materialsProfit,profitOnPlant,jobSheetSigned,callOutRate,initialCallOut,callOutFee,totalToInvoice,siteAllocation,subContractorInvoiceNumber,subContractorInvoiceDate,subContractorInvoicePaid,quotationDated,quotationApprovedDate,timeOnSite2,timeOffSite2,timeOnSite3,timeOffSite3,timeOnSite4,timeOffSite4,siteNotes,addSiteNotes,TimeStamp")] FMIncidentsFM261 fMIncidentsFM261)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fMIncidentsFM261).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fMIncidentsFM261);
        }

        // GET: FMIncidentsFM261/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMIncidentsFM261 fMIncidentsFM261 = db.FMIncidentsFM261.Find(id);
            if (fMIncidentsFM261 == null)
            {
                return HttpNotFound();
            }
            return View(fMIncidentsFM261);
        }

        // POST: FMIncidentsFM261/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FMIncidentsFM261 fMIncidentsFM261 = db.FMIncidentsFM261.Find(id);
            db.FMIncidentsFM261.Remove(fMIncidentsFM261);
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
