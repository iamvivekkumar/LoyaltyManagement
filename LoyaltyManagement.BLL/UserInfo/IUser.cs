using LoyaltyManagement.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyManagement.BLL.User
{
    /// <summary>
    /// Interface for User Operation
    /// </summary>
    public interface IUser
    {
        public UserModel AuthenticateUser(UserModel userModel);
    }
}
