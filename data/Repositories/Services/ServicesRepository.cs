using core.Entities.Services;
using core.Interfaces.Repositories.Services;
using data.Models.Context;
using DTOs.Service;
using Microsoft.EntityFrameworkCore;

namespace data.Repositories.Services
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly LavaderoBDContext _context;
        public ServicesRepository(LavaderoBDContext context)
        {
            _context = context;
        }

        public async Task<Service> GetService(int id)
        {
            var servicio = await _context.tbl_services
                .Include(r => r.idEnterpriceNavigation)
                .Include(r => r.idEnterpriceNavigation)
                .FirstOrDefaultAsync(s => s.id == id);

            if (servicio == null)
            {
                return null;
            }

            return new Service
            {
                Id = servicio.id,
                Categoria = servicio.idCategoryNavigation?.category,
                Empresa = servicio.idEnterpriceNavigation?.enterprice,
                Descripcion = servicio.description,
                Precio = (int)servicio.price,
                IdCategoria = servicio.idCategory,
                IdEmpresa = servicio.idEnterprice
            };
        }

        public async Task<List<Service>> GetServices(ServiceFiltersDto filters)
        {
            var servicio = _context.tbl_services
                .Include(r => r.idEnterpriceNavigation)
                .Include(r => r.idEnterpriceNavigation)
                .Where(s =>
                (
                    (filters.Id != null && s.id == filters.Id) || filters.Id == null)
                    && ((filters.IdEnterprice != 0 && s.idEnterprice == filters.IdEnterprice) || filters.IdEnterprice == 0)
                )
                .Select(servicio => new Service
                {
                    Id = servicio.id,
                    Categoria = servicio.idCategoryNavigation.category,
                    Empresa = servicio.idEnterpriceNavigation.enterprice,
                    Descripcion = servicio.description,
                    Precio = (int)servicio.price,
                    IdCategoria = servicio.idCategory,
                    IdEmpresa = servicio.idEnterprice
                })
                .ToList();

            if (servicio == null)
            {
                return null;
            }

            return servicio;
        }

        public async Task<bool> InsertService(ServiceDto service)
        {
            tbl_service newServicio = new tbl_service
            {
                description = service.Description,
                price = service.Price,
                idCategory = service.idCategory,
                idEnterprice = service.idEnterprice,
            };
            _context.tbl_services.Add(newServicio);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateService(ServiceUpdateDto service)
        {
            try
            {
                var servicio = await _context.tbl_services.FindAsync(service.Id);
                if (servicio == null)
                {
                    return false;
                }
                servicio.price = service.Price;
                servicio.idEnterprice = service.idEnterprice;
                servicio.description = service.Description;
                servicio.idCategory = servicio.idCategory;
                _context.tbl_services.Update(servicio);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteService(int id)
        {
            var servicio = await _context.tbl_services.FindAsync(id);
            if (servicio == null)
            {
                return false;
            }
            _context.tbl_services.Remove(servicio);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ServiceCategoryDto>> GetServicesCategory()
        {
            var servicios = await _context.tbl_service_categories
                .Select(r => new ServiceCategoryDto
                {
                    Id = r.id,
                    Category = r.category
                })
                .ToListAsync();
            return servicios;
        }
    }
}
