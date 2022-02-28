using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Identity.Model
{
    public class Register
    {
        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password must match, please try again.")]
        public string ConfirmPassword { get; set; }
    }
}
