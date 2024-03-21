using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Administration.Events
{
    public class CategoryHaveBeenRemoved : DomainEvent
    {
        public Guid Id { get; set; }
    }
}
