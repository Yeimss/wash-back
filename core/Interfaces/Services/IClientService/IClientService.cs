using core.Entities.Cliente;
using DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces.Services.IClientService
{
    public interface IClientService
    {
        Task<List<Cliente>> GetClient(ClientFilterDto clientFilter, int? idEnterpriceClaim);
    }
}
