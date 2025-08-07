using core.Entities.Cliente;
using core.Interfaces.Repositories.Client;
using core.Interfaces.Services.IClientService;
using DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Cliente>> GetClient(ClientFilterDto clientFilter, int? idEnterpriceClaim)
        {
            List<Cliente> clientes = await _clientRepository.GetClient(clientFilter, idEnterpriceClaim);
            return clientes;
        }
    }
}
