using core.Entities.Services;
using core.Interfaces.Repositories.Services;
using core.Interfaces.Services.IServicesService;
using DTOs.Result;
using DTOs.Service;
using System.Reflection.PortableExecutable;
using System.Security.Claims;

namespace core.Services.Services
{
    public class ServicesService : IServicesService
    {
        private IServicesRepository _servicesRepository;
        public ServicesService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        public async Task<ResultDto> GetServices(IEnumerable<Claim> claims, int? idEnterprice)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol no encontrado en el token", 401);
            }
            ServiceFiltersDto filters = new ServiceFiltersDto { IdEnterprice = idEnterprice ?? 0 };
            if (roleClaim != "1")
            {
                if (string.IsNullOrEmpty(idEnterpriceClaim))
                {
                    return ResultDto.FailResult("El usuario no tiene una empresa asignada", 401);
                }
                filters.IdEnterprice = int.Parse(idEnterpriceClaim);
            }
            else
            {
                if(idEnterprice == null)
                {
                    return ResultDto.FailResult("Al ser admin debes realizar la petición enviando el id de la empresa que deseas consultar", 401);
                }
            }

            var servicios = await _servicesRepository.GetServices(filters);
            if (servicios == null)
            {
                return ResultDto.FailResult("Ha sucedido un error al consultar", 401);
            }
            int statusCode = servicios.Any() ? 200 : 204;
            return ResultDto.SuccessResult(servicios, "Registros consultados exitosamente.", statusCode);
        }
        public async Task<ResultDto> UpdateServices(ServiceUpdateDto serviceUpdate, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;
            
            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol no encontrado en el token", 401);
            }

            ServiceFiltersDto filters = new ServiceFiltersDto { Id = serviceUpdate.Id };
            if (roleClaim != "1")
            {
                if (string.IsNullOrEmpty(idEnterpriceClaim))
                {
                    return ResultDto.FailResult("El usuario no tiene una empresa asignada", 401);
                }
                filters.IdEnterprice = int.Parse(idEnterpriceClaim);
            }
            else
            {
                if (serviceUpdate.idEnterprice == 0)
                {
                    return ResultDto.FailResult("Debes enviar un idEnterprice como parametro", 400);
                }
                filters.IdEnterprice = serviceUpdate.idEnterprice;
            }

            var serviceFinded = await _servicesRepository.GetServices(filters);
            if (serviceFinded == null || !serviceFinded.Any())
            {
                return ResultDto.FailResult("No se encontraron registros con ese id y tu id de empresa para actualizar", 400);
            }

            bool actualizado = await _servicesRepository.UpdateService(serviceUpdate);
            if (!actualizado)
            {
                return ResultDto.FailResult("No se pudo actualizar el registro", 400);
            }
            return ResultDto.SuccessResult(message: "Registro actualizado correctamente", statusCode: 200);

        }
        public async Task<ResultDto> DeleteService(int id, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol no encontrado en el token", 401);
            }

            ServiceFiltersDto filters = new ServiceFiltersDto { Id = id };
            if (roleClaim != "1")
            {
                if (string.IsNullOrEmpty(idEnterpriceClaim))
                {
                    return ResultDto.FailResult("El usuario no tiene una empresa asignada", 401);
                }
                filters.IdEnterprice = int.Parse(idEnterpriceClaim);
            }

            var serviceFinded = await _servicesRepository.GetServices(filters);
            if (serviceFinded == null || !serviceFinded.Any())
            {
                return ResultDto.FailResult("No se encontraron registros con ese id para eliminar", 401);
            }
            bool eliminado = await _servicesRepository.DeleteService(id);
            if (!eliminado)
            {
                return ResultDto.FailResult("No se pudo eliminar el registro", 401);
            }
            return ResultDto.SuccessResult(message: "Registro eliminado correctamente", statusCode: 200);
        }
        public async Task<ResultDto> InsertService(ServiceDto service, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol no encontrado en el token", 401);
            }
            
            if (roleClaim != "1")
            {
                if (string.IsNullOrEmpty(idEnterpriceClaim))
                {
                    return ResultDto.FailResult("El usuario no tiene una empresa asignada", 401);
                }
                service.idEnterprice = int.Parse(idEnterpriceClaim);
            }

            bool insertado = await _servicesRepository.InsertService(service);
            if (!insertado)
            {
                return ResultDto.FailResult("No se pudo insertar el registro", 401);
            }
            return ResultDto.SuccessResult(message: "Registro insertado correctamente", statusCode:200);

        }
        public async Task<ResultDto> GetCategoryServices()
        {
            var services = await _servicesRepository.GetServicesCategory();
            if (services == null)
            {
                return ResultDto.SuccessResult(services ,"No se encontraron categorías de servicios.", 204);
            }
            return ResultDto.SuccessResult(services, "Categorías consultadas correctamente", 201);
        }
    }
}
