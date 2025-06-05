using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using OBAWebAPI.Framework.Domain.Models.Identity;
using OBAWebAPI.Framework.Service.Services;
using System.Security.Claims;

namespace OBAWebAPI.Framework.ApiResponse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] TokenRequestModel request)
        {
            var user = _userService.ValidateCredentials(request.Username, request.Password);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var tokens = _tokenService.GenerateTokens(user.Id, user.Role);
            return Ok(tokens);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Refresh([FromBody] RefreshTokenRequestModel request) 
        {
            ClaimsPrincipal principal;
            try
            {
                principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            }
            catch
            {
                return Unauthorized(new { message = "Invalid access token" });
            }

            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = principal.FindFirstValue(ClaimTypes.Role);

            var tokens = _tokenService.GenerateTokens(userId, role);
            return Ok(tokens);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public IActionResult Me()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.GetById(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out successfully" });
        }
    }
}
