using LoyaltyManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyManagement.DAL.UserInfo
{
    public interface IUserRepository
    {
        public User AuthenticateUser(User user);

        public User RegisterUser(User user);
    }
}
