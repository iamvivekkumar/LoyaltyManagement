using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
