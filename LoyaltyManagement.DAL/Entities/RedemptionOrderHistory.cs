using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class RedemptionOrderHistory
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public int Points { get; set; }
        
    }
}
