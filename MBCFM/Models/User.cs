using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBCFM.Models
{
    [Table("WebUsers")] 
    public class User
    {
        [Key]
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        public string FullName { get; set; }
        public byte[] Salt { get; set; }
    }
}