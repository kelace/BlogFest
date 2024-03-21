using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Search.Queries.DTOs
{
    public class SearchItemDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public SearchItemType SearchItemType { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public DateTime DateCreated { get; set; }
		public string UserName { get; set; }
		public Guid UserId { get; set; }

	}
}
