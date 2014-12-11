using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class ChangePassword
    {
        [Required]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        [StringLength(50, MinimumLength = 8)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Password Confirmation")]
        [StringLength(50, MinimumLength = 8)]
        [Compare("NewPassword")]
        public string Confirmation { get; set; }
    }
}