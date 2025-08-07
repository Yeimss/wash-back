using core.Interfaces.Repositories.Auth;
using core.Interfaces.Services.IAuthService;
using DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace wash_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpPost("CreateUser")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            bool creado = await _service.CreateUser(user);

            if (!creado)
            {
                return BadRequest(new
                {
                    message = "No se ha podido crear el usuario",
                    success = false,
                    status = 400
                });
            }
            return StatusCode(201, new {
                message = "Usuario creado correctamente",
                success = true,
                status = 201
            });
        }

    }
}
