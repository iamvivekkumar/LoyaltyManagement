using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyManagement.BLL.Models
{
    /// <summary>
    /// This class contain user information
    /// </summary>
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }
        
        public string Password { get; set; }
    }
}
