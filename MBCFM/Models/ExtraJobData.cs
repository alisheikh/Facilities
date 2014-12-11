using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    [Table("WebExtraJobData")]
    public class ExtraJobData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //required otherwise entity framwork will assume an identity key as this is an int
        public int MBCJobNo { get; set; }
        public bool? HelpDeskNotified { get; set; }
        public string MaterialsUsed { get; set; }
        public string MaterialsRequired { get; set; }

    }
}