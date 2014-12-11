using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBCFM.Models
{
    [Table("WebJobs")] 
    public class Job
    {
        [Key]
        [Column("MBC Job No")]
        public int MbcJobNo { get; set; }
        [Column("Client Job No")]
        public string ClientJobNo { get; set; }
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
        public decimal? CostsOfMaterials { get; set; }
        public string DurationToCompletion { get; set; }
    }
}