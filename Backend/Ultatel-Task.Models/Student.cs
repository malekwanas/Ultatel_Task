using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ultatel_Task.Models
{
    public enum Gender { Male, Female }
    [Index(nameof(Student_Email), IsUnique = true)]
    public class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public string StudentCreatedBy { get; set; }
        public string? LastAuditedBy { get; set; }
        public DateOnly BirthDate { get; set; }
        [EmailAddress]
        public string Student_Email { get; set; }

        // Add this property for soft delete
        public bool IsDeleted { get; set; } = false;
        public List<Admin> Admins { get; set; }   //M-M table
    }
}
