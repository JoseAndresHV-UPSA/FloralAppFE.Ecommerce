﻿using System.ComponentModel.DataAnnotations;

namespace FloralAppFE.Ecommerce.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
