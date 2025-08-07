using core.Entities.Cliente;
using core.Interfaces.Repositories.Client;
using core.Interfaces.Services.IClientService;
using DTOs.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetClient([FromBody] ClientFilterDto clientFilters)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = User.FindFirst("idEmpresa")?.Value;

            if (role != "1" && string.IsNullOrEmpty(idEnterpriceClaim))
            {
                return Unauthorized(new
                {
                    message = "Usuario sin empresa",
                    status = 401,
                    success = false,
                });
            }

            idEnterpriceClaim = role == "1" ? "0" : idEnterpriceClaim;
            List<Cliente> clientes = await _clientService.GetClient(clientFilters, int.Parse(idEnterpriceClaim));
            if (clientes.Any())
            {
                return Ok(new
                {
                    data = clientes,
                    message = "Consulta realizada correctamente",
                    success = true,
                    status = 200
                });
            }
            else
            {
                return StatusCode(204, new
                {
                    data = clientes,
                    message = "Consulta realizada correctamente",
                    success = true,
                    status = 204
                });
            }
        }
    }
}
