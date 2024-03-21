using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Identity.DTOs
{
	public class LoginUserDTO
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
