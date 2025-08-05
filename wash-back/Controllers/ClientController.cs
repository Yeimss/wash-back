using core.Interfaces.Repositories.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wash_back.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
    }
}
