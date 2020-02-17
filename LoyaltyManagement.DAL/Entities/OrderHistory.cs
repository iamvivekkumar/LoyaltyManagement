using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class OrderHistory
    {
        [Key]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public DateTime DateTime { get; set; }

        public int Points { get; set; }

        public Product Product { get; set; }

        public User User { get; set; }

        public CardDetail CardDetail { get; set; }

        
    }
}
