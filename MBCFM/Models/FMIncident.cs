//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MBCFM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FMIncident
    {
        public int MBC_Job_No { get; set; }
        public string Client_Job_No { get; set; }
        public string SiteNo { get; set; }
        public string OrderType { get; set; }
        public string Trade { get; set; }
        public string EnteredBy { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ReportedBy { get; set; }
        public string SiteTelNo { get; set; }
        public Nullable<System.DateTime> DateOpened { get; set; }
        public Nullable<int> Priority { get; set; }
        public string ResponseTime { get; set; }
        public Nullable<System.DateTime> RequiredBy { get; set; }
        public Nullable<System.DateTime> DateClosed { get; set; }
        public string SubContractor { get; set; }
        public string Note { get; set; }
        public string AddNewNotes { get; set; }
        public string Problem { get; set; }
        public Nullable<System.DateTime> todaysDate { get; set; }
        public Nullable<System.DateTime> timeOnSite { get; set; }
        public Nullable<System.DateTime> timeOffSite { get; set; }
        public Nullable<decimal> materials { get; set; }
        public Nullable<decimal> labour { get; set; }
        public Nullable<decimal> totalCost { get; set; }
        public string currentStatus { get; set; }
        public string costingNotes { get; set; }
        public Nullable<decimal> subContractorMaterials { get; set; }
        public Nullable<decimal> subContractorlabour { get; set; }
        public Nullable<decimal> subContractorcosts { get; set; }
        public Nullable<decimal> subContractorOverheads { get; set; }
        public Nullable<decimal> subContractorProfit { get; set; }
        public Nullable<decimal> subContractorTotal { get; set; }
        public string siteName { get; set; }
        public string siteAddress { get; set; }
        public string siteAddress2 { get; set; }
        public string siteStreet { get; set; }
        public string siteTown { get; set; }
        public string siteCounty { get; set; }
        public string sitePostCode { get; set; }
        public string Invoiced { get; set; }
        public string jobLimits { get; set; }
        public string estimatedTimeOfCompletion { get; set; }
        public string UpliftApprovedBy { get; set; }
        public Nullable<System.DateTime> totalTimeOnSite { get; set; }
        public Nullable<decimal> overHeads { get; set; }
        public Nullable<decimal> materialsProfit { get; set; }
        public Nullable<decimal> profitOnPlant { get; set; }
        public Nullable<bool> jobSheetSigned { get; set; }
        public Nullable<int> callOutRate { get; set; }
        public string initialCallOut { get; set; }
        public Nullable<decimal> callOutFee { get; set; }
        public Nullable<decimal> totalToInvoice { get; set; }
        public string siteAllocation { get; set; }
        public string subContractorInvoiceNumber { get; set; }
        public Nullable<System.DateTime> subContractorInvoiceDate { get; set; }
        public string subContractorInvoicePaid { get; set; }
        public Nullable<System.DateTime> quotationDated { get; set; }
        public Nullable<System.DateTime> quotationApprovedDate { get; set; }
        public Nullable<System.DateTime> timeOnSite2 { get; set; }
        public Nullable<System.DateTime> timeOffSite2 { get; set; }
        public Nullable<System.DateTime> timeOnSite3 { get; set; }
        public Nullable<System.DateTime> timeOffSite3 { get; set; }
        public Nullable<System.DateTime> timeOnSite4 { get; set; }
        public Nullable<System.DateTime> timeOffSite4 { get; set; }
        public string siteNotes { get; set; }
        public string addSiteNotes { get; set; }
    }
}
