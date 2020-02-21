using AutoMapper;
using LoyaltyManagement.API.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoyaltyManagement.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private BLL.User.IUser _userInfo;

        public RegistrationController(BLL.User.IUser userInfo, IMapper mapper)
        {
            _mapper = mapper;
            _userInfo = userInfo;
        }


        [HttpPost]
        public IActionResult UserRegistration([FromBody]UserRegistrationDto userRegistrationDto)
        {
            try
            {
                var userInfo = _mapper.Map<BLL.Models.UserModel>(userRegistrationDto);

                var user = _userInfo.RegisterUser(userInfo);

                return Created("", user);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}