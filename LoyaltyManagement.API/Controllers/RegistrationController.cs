using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoyaltyManagement.API.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyManagement.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            IActionResult response =  Ok();

            if (!ModelState.IsValid)
            {

            }

             var userInfo = _mapper.Map<BLL.Models.UserModel>(userRegistrationDto);

            var user = _userInfo.RegisterUser(userInfo);


            return Created("", user);
        }

    }
}