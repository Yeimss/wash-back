using core.Interfaces.Repositories.Client;
using core.Interfaces.Services.IClientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetClient(int id)
        {
            return Ok("nashe"); 
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok("perron");
        }
    }
}
