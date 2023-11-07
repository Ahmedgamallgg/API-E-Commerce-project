using Core.IdentityEntities;
using E_Commerce.HandelResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.TokenService.Interface;
using Services.UserService;
using Services.UserService.Dto;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly IUserService _UserService;
        private readonly UserManager<AppUser> _UserManager;

        public AccountController(IUserService userService, UserManager<AppUser> userManager)
        {
            _UserService = userService;
            _UserManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>>  Register(RegisterDto registerDto)
        {
            var user = await _UserService.Register(registerDto);
            if (user == null)
                return BadRequest(new ApiException(400, "Email Already Exist"));

            return Ok(user);
            
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _UserService.Login(loginDto);
            if (user == null)
                return Unauthorized(new ApiResponse(401));

            return Ok(user);

        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            //var email = HttpContext.User?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.Email).Value;
            var email = User?.FindFirstValue(ClaimTypes.Email);

            if (email == null)
                return Unauthorized(new ApiResponse(401));

            var user = await _UserManager.FindByEmailAsync(email);

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email
            };


        }


    }
}
