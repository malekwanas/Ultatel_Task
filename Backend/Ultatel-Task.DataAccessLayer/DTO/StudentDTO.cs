using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultatel_Task.Models;

namespace Ultatel_Task.DataAccessLayer.DTO
{
    public class StudentDTO
    {
        public int Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public string StudentCreatedBy { get; set; }
        public string? LastAuditedBy { get; set; }
        public DateOnly BirthDate { get; set; }
        [EmailAddress]
        public string Student_Email { get; set; }
    }
}
