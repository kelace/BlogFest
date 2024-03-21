﻿using System.ComponentModel.DataAnnotations;

namespace BlogFest.Models.Authorization
{
    public class LoginUserViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
