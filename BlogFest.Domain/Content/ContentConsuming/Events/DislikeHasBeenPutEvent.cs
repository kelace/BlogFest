using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Content.ContentConsuming
{
    public class DislikeHasBeenPutEvent : DomainEvent
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
