using core.Entities.Cliente;
using core.Interfaces.Repositories.Client;
using data.Models.Context;
using DTOs.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace data.Repositories.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly LavaderoBDContext _context;
        public ClientRepository(LavaderoBDContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetClient(ClientFilterDto clientFilters, int? idEnterprice)
        {
            //List<tbl_client> clientes= await _context.tbl_clients
            //    .Where(r => idEnterprice != 0 );
            //if (cliente == null)
            //{
            //    return null;
            //}
            return null;
        }
    }
}
