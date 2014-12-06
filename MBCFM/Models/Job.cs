using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class Job
    {
        public int MbcJobNo { get; set; }
        public int ClientJobNo { get; set; }
        public int Priority { get; set; }
        public string ClientName { get; set; }
        public string Client { get; set; }
        public string CurrentStatus { get; set; }
        public string OrderType { get; set; }
        public string SitePhoneNo { get; set; }
        public string Problem { get; set; }
        public string UserName { get; set; }

        public virtual User SubContractor { get; set; }
    }
}