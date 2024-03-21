using BlogFest.Domain.Base;
using BlogFest.Domain.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Content.ContentCreating
{
    public class PostHasBeenPublishedEvent : DomainEvent
    {
        public Guid Id { get; set; }
        public PostStatus Status { get; set; }
    }
}
