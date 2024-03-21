using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Queries.DTOs
{
    public class AdminUserForEditDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActived { get; set; }
        public bool IsCreatePostAllowed { get; set; }
        public bool IsCommentAllowed { get; set; }
    }
}
