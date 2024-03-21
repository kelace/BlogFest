using System.ComponentModel.DataAnnotations;

namespace BlogFest.Models.Authorization
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Password is required")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name= "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
