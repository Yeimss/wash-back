using core.Entities.Cliente;
using DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces.Repositories.Client
{
    public interface IClientRepository
    {
        Task<List<Cliente>> GetClient(ClientFilterDto clientFilters, int? idEnterprice);
        Task<int> InsertClient(ClientDto client);
    }
}
