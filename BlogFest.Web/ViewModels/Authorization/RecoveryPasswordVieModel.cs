using System.ComponentModel.DataAnnotations;

namespace BlogFest.Web.ViewModels.Authorization
{
    public class RecoveryPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required") ]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
