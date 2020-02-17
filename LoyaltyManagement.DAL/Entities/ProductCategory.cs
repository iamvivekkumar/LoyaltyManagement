using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class ProductCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        public decimal MinimumSpend { get; set; }

        public int Points { get; set; }

        public bool IsActive { get; set; }
    }
}
