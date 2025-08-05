using core.Interfaces.Repositories.Auth;
using DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wash_back.DTOs.Auth;

namespace wash_back.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserDto user)
        {

            return Ok(user);
        }
        [Authorize(Roles = "1")]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser()
        {
            return Ok("Siuuuuuuuuuuuu");
        }

    }
}
