using core.Entities.Wash;
using core.Entities.Cliente;
using core.Entities.Services;
using core.Interfaces.Repositories.Washed;
using data.Models.Context;
using DTOs.Washed;
using Microsoft.EntityFrameworkCore;

namespace data.Repositories.Washed
{
    public class WashedRepository : IWashedRepository
    {
        private readonly LavaderoBDContext _context;
        public WashedRepository(LavaderoBDContext context) 
        {
            _context = context;
        }

        public async Task<Wash> GetWash(int id)
        {
            var lavada = await _context.tbl_washeds
                .Include(w => w.idEnterpriceNavigation)
                .Include(w => w.idClientNavigation)
                .Include(w => w.idEncargadoNavigation)
                .Include(w => w.idServiceNavigation)
                    .ThenInclude(s => s.idCategoryNavigation)
                .Select(w => new Wash
                {
                    Id = w.id,
                    IdEnterprice = w.idEnterprice ?? 0,
                    Enterprice = w.idEnterpriceNavigation.enterprice,
                    IdEncargado = w.idEncargado,
                    Encargado = w.idEncargadoNavigation.name,
                    Cliente = new Cliente
                    {
                        id = w.idClientNavigation.id,
                        email = w.idClientNavigation.email,
                        phone = w.idClientNavigation.phone,
                        placa = w.idClientNavigation.placa,
                        name = w.idClientNavigation.name
                    },
                    Servicio = new Service
                    {
                        Id = w.idServiceNavigation.id,
                        Precio = (int)w.idServiceNavigation.price,
                        Categoria = w.idServiceNavigation.idCategoryNavigation.category,
                        IdCategoria = w.idServiceNavigation.idCategory,
                        Descripcion = w.idServiceNavigation.description,
                    },
                    admissionDate = w.admissionDate,
                    depurateDate = w.departureDate,
                    IsWashed = w.isWashed,
                    IsPaid = w.isPaid
                })
                .FirstOrDefaultAsync(w => w.Id == id);
            return lavada;
        }

        public async Task<List<Wash>> GetWashed(WashedFiltersDto filters)
        {
            var query = _context.tbl_washeds
            .Include(w => w.idEnterpriceNavigation)
            .Include(w => w.idClientNavigation)
            .Include(w => w.idEncargadoNavigation)
            .Include(w => w.idServiceNavigation)
                .ThenInclude(s => s.idCategoryNavigation)
            .AsQueryable();

            if (!string.IsNullOrEmpty(filters.IdEnterprice))
                query = query.Where(w => w.idEnterprice.ToString() == filters.IdEnterprice);

            if (filters.IsWashed.HasValue)
                query = query.Where(w => w.isWashed == filters.IsWashed.Value);

            if (filters.IsPaid.HasValue)
                query = query.Where(w => w.isPaid == filters.IsPaid.Value);


            var lavadas = await query
                .Select(w => new Wash
                {
                    Id = w.id,
                    IdEnterprice = w.idEnterprice ?? 0,
                    Enterprice = w.idEnterpriceNavigation.enterprice,
                    IdEncargado = w.idEncargado,
                    Encargado = w.idEncargadoNavigation.name,
                    Cliente = new Cliente
                    {
                        id = w.idClientNavigation.id,
                        email = w.idClientNavigation.email,
                        phone = w.idClientNavigation.phone,
                        placa = w.idClientNavigation.placa,
                        name = w.idClientNavigation.name
                    },
                    Servicio = new Service
                    {
                        Id = w.idServiceNavigation.id,
                        Precio = (int)w.idServiceNavigation.price,
                        Categoria = w.idServiceNavigation.idCategoryNavigation.category,
                        IdCategoria = w.idServiceNavigation.idCategory,
                        Descripcion = w.idServiceNavigation.description,
                    },
                    admissionDate = w.admissionDate,
                    depurateDate = w.departureDate,
                    IsWashed = w.isWashed,
                    IsPaid = w.isPaid
                })
                .ToListAsync();
            return lavadas;
        }

        public async Task<bool> Insert(WashedDto wash)
        {
            tbl_washed lavada = new tbl_washed
            {
                idClient = wash.IdClient,
                idEncargado = wash.IdEncargado,
                idService = wash.IdService,
                idEnterprice = wash.IdEnterprice,
            };
            await _context.tbl_washeds.AddAsync(lavada);
            int insertado = await _context.SaveChangesAsync();
            return insertado > 0;
        }

        public async Task<bool> UpdateWash(WashedUpdateDto wash)
        {
            var lavada = await _context.tbl_washeds.FindAsync(wash.Id);
            if (lavada == null)
            {
                return false;
            }
            lavada.isPaid = wash.IsPaid;
            lavada.isWashed = wash.IsWashed;
            lavada.idClient = wash.IdClient;
            lavada.idEnterprice = wash.IdEnterprice;
            lavada.idEncargado = wash.IdEncargado;
            lavada.idService = wash.IdService;
            _context.tbl_washeds.Remove(lavada);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteWashed(int id)
        {
            var lavada = await _context.tbl_washeds.FindAsync(id);
            if (lavada == null)
            {
                return false;
            }
            _context.tbl_washeds.Remove(lavada);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
