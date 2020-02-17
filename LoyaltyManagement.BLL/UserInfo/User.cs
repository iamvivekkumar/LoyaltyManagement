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
        /// for getting user authentocation
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserModel AuthenticateUser(UserModel userModel)
        {
            var user = _mapper.Map<DAL.Entities.User>(userModel);
            var userInfo = _userInfo.AuthenticateUser(user);
            
            //if(userInfo != null)
            //{
            //    return _mapper.Map<UserModel>(userInfo);
            //}

            //return null;

            return _mapper.Map<UserModel>(userInfo);

        }
    }
}
