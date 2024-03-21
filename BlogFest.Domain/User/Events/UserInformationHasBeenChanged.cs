using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.User.Events
{
	public class UserInformationHasBeenChanged : DomainEvent
	{
		public Guid UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid? PhotoId { get; set; }
		public string Bio { get; set; }
	}
}
