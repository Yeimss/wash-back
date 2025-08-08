using core.Entities.Cliente;
using core.Interfaces.Repositories.Client;
using core.Interfaces.Services.IClientService;
using DTOs.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace wash_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService service)
        {
            _clientService = service;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetClient([FromBody] ClientFilterDto clientFilters)
        {
            var claims = User.Claims;
            var result = await _clientService.GetClient(clientFilters, claims);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] ClientDto client)
        {
            var claims = User.Claims;
            var result = await _clientService.InsertClient(client, claims);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ClientUpdateDto client)
        {
            var claims = User.Claims;
            var result = await _clientService.UpdateClient(client, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var claims = User.Claims;
            var result = await _clientService.DeleteClient(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
