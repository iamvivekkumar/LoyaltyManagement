using AutoMapper;
using LoyaltyManagement.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyManagement.BLL.User
{
    /// <summary>
    /// A clas for user operation
    /// </summary>
    public class User : IUser
    {
        
        private DAL.UserInfo.IUserRepository _userInfo;
        private readonly IMapper _mapper;

        public User(DAL.UserInfo.IUserRepository userInfo, IMapper mapper)
        {
            _mapper = mapper;
            _userInfo = userInfo;
        }

        /// <summary>
        /// for getting user authentication
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserModel AuthenticateUser(UserModel userModel)
        {
            var user = _mapper.Map<DAL.Entities.User>(userModel);
            var userInfo = _userInfo.AuthenticateUser(user);
            
            return _mapper.Map<UserModel>(userInfo);

        }

        public UserModel RegisterUser(UserModel userModel)
        {
            var user = _mapper.Map<DAL.Entities.User>(userModel);
            var userInfo = _userInfo.RegisterUser(user);

            return _mapper.Map<UserModel>(userInfo);

        }
    }
}
