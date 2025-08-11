using core.Interfaces.Repositories.Attendant;
using core.Interfaces.Services.Attendant;
using DTOs.Attendant;
using DTOs.Result;
using System.Security.Claims;

namespace core.Services.Attendant
{
    public class AttendantService : IAttendantService
    {
        private readonly IAttendantRepository _attendantRepository;
        public AttendantService(IAttendantRepository attendantRepository)
        {
            _attendantRepository = attendantRepository;
        }
        public async Task<ResultDto> GetAll(IEnumerable<Claim> claims, int? idEnterprice)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }
            if (roleClaim != "1")
            {
                idEnterprice = int.Parse(idEnterpriceClaim);
            }
            var empleados = await _attendantRepository.GetAll(idEnterprice ?? 0);
            int StatusCode = (empleados == null || !empleados.Any()) ? 204 : 200;

            return ResultDto.SuccessResult(data: empleados, message: "No se encontró información", statusCode: StatusCode);
        }
        public async Task<ResultDto> Insert(AttendantDto attendant, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }
            if (roleClaim != "1")
            {
                attendant.IdEnterprice = int.Parse(idEnterpriceClaim);
            }
            else if (attendant.IdEnterprice == null)
            {
                return ResultDto.FailResult("Debes ingresar el id de la empresa", 400);
            }
            
            bool insertado = await _attendantRepository.Insert(attendant);
            if (!insertado)
            {
                return ResultDto.FailResult("Error insertando el registro", 400);
            }
            return ResultDto.SuccessResult(message: "Registro insertado correctamente", statusCode:201);
        }
        public async Task<ResultDto> Update(AttendantUpdateDto attendant, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }
            if (roleClaim != "1")
            {
                attendant.IdEnterprice = int.Parse(idEnterpriceClaim);
            }
            else if (attendant.IdEnterprice == null)
            {
                return ResultDto.FailResult("Debes ingresar el id de la empresa", 400);
            }

            var empleado = await _attendantRepository.Get(attendant.Id);
            if (empleado == null)
            {
                return ResultDto.FailResult("No se encontró el registro para actualizar", 400);
            }
            if (empleado.IdEnterprice != attendant.IdEnterprice)
            {
                return ResultDto.FailResult("El empleado pertenece a una empresa diferente, no se puede actualizar", 400);
            }
            bool actualizado = await _attendantRepository.Update(attendant);
            if (!actualizado)
            {
                return ResultDto.FailResult("Error actualizando el registro", 400);
            }
            return ResultDto.SuccessResult(message: "Registro actualizado correctamente", statusCode: 200);

        }
        public async Task<ResultDto> Delete(int id, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }
            var empleado = await _attendantRepository.Get(id);
            if (empleado == null)
            {
                return ResultDto.FailResult("No se encontró el registro para eliminar", 400);
            }

            if (roleClaim != "1")
            {
                if (empleado.IdEnterprice != int.Parse(idEnterpriceClaim))
                {
                    return ResultDto.FailResult("El empleado pertenece a una empresa diferente, no se puede eliminar", 400);
                }
            }
            bool eliminado = await _attendantRepository.Delete(id);
            if (!eliminado)
            {
                return ResultDto.FailResult("Error eliminando el registro", 400);
            }
            return ResultDto.SuccessResult(message: "Registro eliminado correctamente", statusCode: 200);
        }
    }
}
