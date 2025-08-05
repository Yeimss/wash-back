using core.Interfaces.Repositories.Auth;
using core.Interfaces.Services.IAuthService;
using DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using wash_back.DTOs.Auth;

namespace wash_back.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            string? token = await _service.Login(user);
            return Ok(new
            {
                token = token,
                message = !token.IsNullOrEmpty() ? "Se inició sesión con exito" : "Credenciales incorrectas",
                success = !token.IsNullOrEmpty() ? true : false
            });
        }
        [Authorize(Roles = "1")]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser()
        {
            return Ok("Siuuuuuuuuuuuu");
        }

    }
}
