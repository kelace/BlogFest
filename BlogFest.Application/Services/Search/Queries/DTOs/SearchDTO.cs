using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Search.Queries.DTOs
{
    public class SearchDTO
    {
        public int Count { get; set; }
        public List<SearchItemDTO> SearchResult { get; set; }
        public int Page { get; set; }
        public string Key { get; set; }
    }
}
