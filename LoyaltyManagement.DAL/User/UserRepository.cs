using LoyaltyManagement.DAL.Context;
using LoyaltyManagement.DAL.Entities;
using System.Linq;

namespace LoyaltyManagement.DAL.UserInfo
{
    public class UserRepository : IUserRepository
    {
        private LoyalityContext loyalityContext;

        public UserRepository(LoyalityContext loyalityContext)
        {
            this.loyalityContext = loyalityContext;
        }

        public User AuthenticateUser(User user)
        {
            var userinfo = (from n in loyalityContext.Users
                            where n.Email == user.Email && n.Password == user.Password
                           select n)
                           .FirstOrDefault();

            return userinfo;
        }
    }
}
