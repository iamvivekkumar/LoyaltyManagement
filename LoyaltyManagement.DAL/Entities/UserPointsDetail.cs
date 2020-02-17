using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class UserPointsDetail
    {
        [Key]
        public Guid Id { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public int Points { get; set; }

        public int Type { get; set; }
    }
}
