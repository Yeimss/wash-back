using core.Entities.Services;
using DTOs.Service;

namespace core.Interfaces.Repositories.Services
{
    public interface IServicesRepository
    {
        Task<Service> GetService(int id);
        Task<List<Service>> GetServices(ServiceFiltersDto filters);
        Task<bool> InsertService(ServiceDto service);
        Task<bool> UpdateService(ServiceUpdateDto service);
        Task<bool> DeleteService(int it);
        Task<List<ServiceCategoryDto>> GetServicesCategory();
    }
}
