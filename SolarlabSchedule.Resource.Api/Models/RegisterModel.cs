﻿using System.ComponentModel.DataAnnotations;

namespace SolarlabSchedule.Resource.Api.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}