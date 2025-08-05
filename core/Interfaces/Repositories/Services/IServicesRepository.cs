using core.Entities.Services;
using DTOs.Service;

namespace core.Interfaces.Repositories.Services
{
    public interface IServicesRepository
    {

        Task<Service> GetServices();
        Task<Service> GetService(int id);
        Task<Service> InsertService(ServiceDto service);
    }
}
