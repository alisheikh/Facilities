using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}