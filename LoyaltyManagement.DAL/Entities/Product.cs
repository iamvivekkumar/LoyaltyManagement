using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string name { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ProductCategory ProductCategory { get; set; }

        
    }
}
