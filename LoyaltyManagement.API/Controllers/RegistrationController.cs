using AutoMapper;
using LoyaltyManagement.API.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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

                return user != null ? Created("", user) : StatusCode(StatusCodes.Status409Conflict, $"An existing record with the Email '{userRegistrationDto.Email}' was already found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}