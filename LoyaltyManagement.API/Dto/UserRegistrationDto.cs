﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyManagement.API.Dto
{
    public class UserRegistrationDto
    {
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
