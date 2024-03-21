using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Identity.DTOs
{
	public class ResetPasswordDTO
	{
		public string Email { get; set; }
		public string Code { get; set; }
		public string Password { get; set; }
		public string PasswordConfirm { get; set; }
	}
}
