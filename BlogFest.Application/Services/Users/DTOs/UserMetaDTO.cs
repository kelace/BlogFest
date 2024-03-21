using BlogFest.Application.Services.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Users.DTOs
{
    public class UserMetaDTO
    {
        public bool IsAdmin { get; set; }
        public UserPageDTO UserPage { get; set; }
    }
}
