using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class CardDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        public decimal MinAmount { get; set; }

        public decimal MaxAmount { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }
    }
}
