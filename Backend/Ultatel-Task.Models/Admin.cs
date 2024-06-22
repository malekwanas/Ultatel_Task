using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ultatel_Task.Models
{
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //ID is National ID
        public int Admin_ID { get; set; }

        [Required]
        public string AdminName { get; set; }
        public List<Student> Students { get; set; }   //M-M table

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
