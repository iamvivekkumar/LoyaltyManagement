using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LoyaltyManagement.API.Dto;
using LoyaltyManagement.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LoyaltyManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IMapper _mapper;
        private BLL.User.IUser _userInfo;

        public AuthController(BLL.User.IUser userInfo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _userInfo = userInfo;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserLoginDto userLoginDto)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userInfo = _mapper.Map<BLL.Models.UserModel>(userLoginDto);

                var user = _userInfo.AuthenticateUser(userInfo);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString });
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To Generate Token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(UserModel userInfo)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,userInfo.Role)
            };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}