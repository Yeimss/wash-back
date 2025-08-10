using core.Entities.Wash;
using core.Interfaces.Repositories.Washed;
using core.Interfaces.Services.Washed;
using DTOs.Result;
using DTOs.Washed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace core.Services.Washed
{
    public class WashedService : IWashedService
    {
        private readonly IWashedRepository _washedRepository;
        public WashedService(IWashedRepository washedService)
        {
            _washedRepository = washedService;
        }

        public async Task<ResultDto> Get(int id, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }

            var lavada = await _washedRepository.GetWash(id);
            if (roleClaim != "1")
            {
                if(lavada.IdEncargado != int.Parse(idEnterpriceClaim))
                {
                    return ResultDto.FailResult("El la empersa no coincide con el usuario loggeado", 401);
                }
            }
            int statusCode = (lavada == null) ? 204 : 200;
            return ResultDto.SuccessResult(lavada, "Resultado obtenido", statusCode);
        }
        public async Task<ResultDto> GetAll(WashedFiltersDto filters, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }

            if(roleClaim != "1")
            {
                filters.IdEnterprice = int.Parse(idEnterpriceClaim);
            }
            else
            {
                if(filters.IdEnterprice == null)
                {
                    return ResultDto.FailResult("Debes filtrar por empresa", 400);
                }
            }

            var lavadas = await _washedRepository.GetWashed(filters);
            int statusCode = (lavadas == null || !lavadas.Any()) ? 204 : 200;
            return ResultDto.SuccessResult(lavadas, "Resultados obtenidos", statusCode);
        }
        public async Task<ResultDto> Insert(WashedDto wash, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }

            if (roleClaim != "1")
            {
                wash.IdEnterprice = int.Parse(idEnterpriceClaim);
            }
            else
            {
                if (wash.IdEnterprice == null)
                {
                    return ResultDto.FailResult("Debes insertar el id de la empresa", 400);
                }
            }

            var lavadas = await _washedRepository.Insert(wash);
            if (!lavadas)
            {
                return ResultDto.FailResult("Error insertando", 400);
            }
            return ResultDto.SuccessResult(message: "Exito insertando", statusCode: 201);

        }
        public async Task<ResultDto> Update(WashedUpdateDto wash, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }

            if (roleClaim != "1")
            {
                wash.IdEnterprice = int.Parse(idEnterpriceClaim);
            }
            else
            {
                if (wash.IdEnterprice == null)
                {
                    return ResultDto.FailResult("Debes insertar el id de la empresa", 400);
                }
            }
            var lavadaFinded = await _washedRepository.GetWash(wash.Id);
            if(lavadaFinded == null)
            {
                return ResultDto.FailResult("No se encontró un registro para actualizar", 400);
            }

            var lavadas = await _washedRepository.UpdateWash(wash);
            if (!lavadas)
            {
                return ResultDto.FailResult("Error actualizando", 400);
            }
            return ResultDto.SuccessResult(message: "Exito actualizando", statusCode: 200);
        }
        public async Task<ResultDto> Delete(int id, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol del usuario no encontrado", 401);
            }

            var lavadaFinded = await _washedRepository.GetWash(id);
            if (roleClaim != "1")
            {
                if (lavadaFinded.IdEnterprice != int.Parse(idEnterpriceClaim))
                {
                    return ResultDto.FailResult("No tienes permiso para eliminar este registro", 401);
                }
            }

            if (lavadaFinded == null)
            {
                return ResultDto.FailResult("No se encontró un registro para actualizar", 400);
            }

            var eliminado = await _washedRepository.DeleteWashed(id);
            if (!eliminado)
            {
                return ResultDto.FailResult("Error eliminando", 400);
            }
            return ResultDto.SuccessResult(message: "Exito eliminando", statusCode: 200);
        }
    }
}
