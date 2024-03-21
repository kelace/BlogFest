using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
    }
}
