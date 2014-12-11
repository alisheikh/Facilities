using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class MergedJob
    {
        public Job Job { get; set; }
        public ExtraJobData  ExtraData { get; set; }
    }
}