using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyManagement.DAL.Entities
{
    public class UserCardDetail
    {
        [Key]
        public Guid Id { get; set; }

        public int TotalEarnPoints { get; set; }

        public int Balance { get; set; }

        public User User { get; set; }

        public CardDetail Card { get; set; }
    }
}
