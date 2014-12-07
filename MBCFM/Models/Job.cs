using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class Job
    {
        [Key]
        public int MbcJobNo { get; set; }
        public int ClientJobNo { get; set; }
        public int? Priority { get; set; }
        public string ClientName { get; set; }
        public string CurrentStatus { get; set; }
        public string OrderType { get; set; }
        public string SitePhoneNo { get; set; }
        public string Problem { get; set; }
        public string UserName { get; set; }
        public string EnteredBy { get; set; }
        public string Notes { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string MaterialsUsed { get; set; }
        public string CostsOfMaterials { get; set; }
        public string MaterialsRequired { get; set; }
        public string DurationToCompletion { get; set; }
    }
}