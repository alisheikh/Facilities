using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class NotificationView
    {
        public IEnumerable<MergedJob> HelpdeskJobs { get; set; }
        public IEnumerable<MergedJob> OpenJobs { get; set; }
    }
}