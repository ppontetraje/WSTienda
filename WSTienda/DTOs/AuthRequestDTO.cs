﻿using System.ComponentModel.DataAnnotations;

namespace WSTienda.DTOs
{
    public class AuthRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
