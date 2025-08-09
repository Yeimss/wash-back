using core.Interfaces.Repositories.Services;
using DTOs.Result;
using DTOs.Service;
using System.Security.Claims;

namespace core.Interfaces.Services.IServicesService
{
    public interface IServicesService
    {
        Task<ResultDto> GetServices(IEnumerable<Claim> claims, int? idEnterprice);
        Task<ResultDto> InsertService(ServiceDto service, IEnumerable<Claim> claims);
        Task<ResultDto> UpdateServices(ServiceUpdateDto serviceUpdate, IEnumerable<Claim> claims);
        Task<ResultDto> DeleteService(int id, IEnumerable<Claim> claims);
        Task<ResultDto> GetCategoryServices();
    }
}
