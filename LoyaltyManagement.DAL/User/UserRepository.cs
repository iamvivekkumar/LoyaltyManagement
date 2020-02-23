using LoyaltyManagement.DAL.Context;
using LoyaltyManagement.DAL.Entities;
using System;
using System.Linq;

namespace LoyaltyManagement.DAL.UserInfo
{
    /// <summary>
    /// A class for user related operation
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private LoyalityContext loyalityContext;

        public UserRepository(LoyalityContext loyalityContext)
        {
            this.loyalityContext = loyalityContext;
        }

        /// <summary>
        /// To authenticate user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AuthenticateUser(User user)
        {
            try
            {
                var userinfo = (from n in loyalityContext.Users
                                where n.Email == user.Email && n.Password == user.Password
                                select n)
                               .FirstOrDefault();

                return userinfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To Register User
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>User</returns>
        public User RegisterUser(User user)
        {
            try
            {
                if (IsUserExist(user.Email))
                {
                    return null;
                }
                user.Id = new Guid();
                loyalityContext.Users.Add(user);
                loyalityContext.SaveChanges();

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsUserExist(string email)
        {
            try
            {
                var user = (from n in loyalityContext.Users
                                   where n.Email == email
                                   select n)
                                   .FirstOrDefault();

                return user != null? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
