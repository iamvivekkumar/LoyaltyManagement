using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LoyaltyManagement.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private BLL.User.IUser _userInfo;

        public UserController(BLL.User.IUser userInfo, IMapper mapper)
        {
            _mapper = mapper;
            _userInfo = userInfo;
        }

        [HttpGet]
        public IActionResult GetUser(int id)
        {
            var userId = User.FindFirst("sub")?.Value;
            var userRole = User.FindFirst("role")?.Value;

           return Ok();
        }
    }
}