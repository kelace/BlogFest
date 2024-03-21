using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Identity.DTOs
{
	public class RecoveryPasswordDTO
	{
		public string Email { get; set; }
	}
}
