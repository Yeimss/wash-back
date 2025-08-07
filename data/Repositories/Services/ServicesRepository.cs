using core.Entities.Services;
using core.Interfaces.Repositories.Services;
using data.Models.Context;
using DTOs.Service;

namespace data.Repositories.Services
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly LavaderoBDContext _context;
        public ServicesRepository(LavaderoBDContext context)
        {
            _context = context;
        }

        public Task<Service> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetServices()
        {
            throw new NotImplementedException();
        }

        public Task<Service> InsertService(ServiceDto service)
        {
            throw new NotImplementedException();
        }
    }
}
