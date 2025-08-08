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
            var query = _context.tbl_clients.AsQueryable();

            if (idEnterprice != null && idEnterprice != 0)
            {
                query = query.Where(c => c.idEnterprice == idEnterprice);
            }

            if (clientFilters.Id != 0 && clientFilters.Id != null)
            {
                query = query.Where(c => c.id == clientFilters.Id);
            }

            if (!string.IsNullOrWhiteSpace(clientFilters.Phone))
            {
                query = query.Where(c => c.phone.Contains(clientFilters.Phone));
            }

            if (!string.IsNullOrWhiteSpace(clientFilters.Placa))
            {
                query = query.Where(c => c.placa.ToUpper().Contains(clientFilters.Placa));
            }


            var clientesDb = await query
                .Include(c => c.idEnterpriceNavigation)
                .ToListAsync();

            var clientes = clientesDb.Select(c => new Cliente
            {
                id = c.id,
                name = c.name,
                email = c.email,
                phone = c.phone,
                placa = c.placa,
                idEmpresa = c.idEnterprice,
                empresa = c.idEnterpriceNavigation?.enterprice
                
            }).ToList();

            return clientes;
        }
        public async Task<int> InsertClient(ClientDto client)
        {
            tbl_client cliente = new tbl_client
            {
                name = client.Name,
                email = client.Email,
                phone = client.Phone,
                placa = client.Placa,
                idEnterprice = client.IdEnterprice
            };
            await _context.AddAsync(cliente);
            var res = await _context.SaveChangesAsync();
            return res;
        }
        public async Task<bool> UpdateClient(ClientUpdateDto client)
        {
            var cliente = await _context.tbl_clients.FindAsync(client.Id);
            if (cliente == null)
            {
                return false;
            }
            cliente.email = client.Email;
            cliente.phone = client.Phone;
            cliente.placa = client.Placa;
            cliente.name = client.Name;
            cliente.idEnterprice = client.IdEnterprice;

            _context.tbl_clients.Update(cliente);
            await _context.SaveChangesAsync();
            return true;
        } 
        public async Task<bool> DeleteClient(int id)
        {
            var cliente = await _context.tbl_clients.FindAsync(id);
            if(cliente == null)
            {
                return false;
            }

            _context.tbl_clients.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
