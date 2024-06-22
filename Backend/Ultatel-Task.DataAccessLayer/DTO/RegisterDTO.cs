using System.ComponentModel.DataAnnotations;

namespace Ultatel_Task.DataAccessLayer.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string AdminName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation aren't matching.")]
        public string ConfirmPassword { get; set; }
    }
}
