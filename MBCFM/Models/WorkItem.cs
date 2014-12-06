using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class WorkItem
    {
        public int MBCJobNo { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string MaterialsUsed { get; set; }
        public string CostsOfMaterials { get; set; }
        public string MaterialsRequired { get; set; }
        public string DurationToComplete { get; set; }
    }
}