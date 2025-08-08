using core.Interfaces.Repositories.Client;
using core.Interfaces.Services.IClientService;
using DTOs.Client;
using DTOs.Result;
using System.Security.Claims;

namespace core.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public async Task<ResultDto> GetClient(ClientFilterDto clientFilters, IEnumerable<Claim> claims)
        {
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var idEnterpriceClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (string.IsNullOrEmpty(roleClaim))
            {
                return ResultDto.FailResult("Rol no encontrado en el token", 401);
            }

            if (roleClaim != "1" && string.IsNullOrEmpty(idEnterpriceClaim))
            {
                return ResultDto.FailResult("Usuario sin empresa asignada", 401);
            }

            int idEnterprice = roleClaim == "1" ? 0 : int.Parse(idEnterpriceClaim);

            var clientes = await _clientRepository.GetClient(clientFilters, idEnterprice);

            if (clientes.Any())
            {
                return ResultDto.SuccessResult(clientes, "Consulta realizada correctamente", 200);
            }

            return ResultDto.SuccessResult(clientes, "No se encontraron clientes", 204);

        }

        public async Task<ResultDto> InsertClient(ClientDto client, IEnumerable<Claim> claims)
        {

            var rolClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var empresaClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (rolClaim == null || (empresaClaim == null && !rolClaim.Equals("1")))
            {
                return ResultDto.FailResult("No se pudo validar la identidad del usuario");
            }
            int rol = int.Parse(rolClaim);

            if (rol != 1)            {
                client.IdEnterprice = int.Parse(empresaClaim);
            }
            else
            {
                if (client.IdEnterprice == 0)
                {
                    return ResultDto.FailResult("Debe especificar una empresa válida");
                }
            }

            client.Placa = client.Placa.ToUpper();
            int cantAfectada = await _clientRepository.InsertClient(client);
            string mensaje = cantAfectada > 0 ? "Insertado correctamente" : "No se pudo insertar el registro";
            int statusCode = cantAfectada > 0 ? 200 : 400;
            return ResultDto.SuccessResult(message: mensaje, statusCode: statusCode);
        }
        public async Task<ResultDto> UpdateClient(ClientUpdateDto client, IEnumerable<Claim> claims)
        {

            var rolClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var empresaClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (rolClaim == null || (empresaClaim == null && !rolClaim.Equals("1")))
            {
                return ResultDto.FailResult("No se pudo validar la identidad del usuario");
            }

            int rol = int.Parse(rolClaim);

            if (rol != 1)
            {
                client.IdEnterprice = int.Parse(empresaClaim);
            }
            else
            {
                if (client.IdEnterprice == 0)
                {
                    return ResultDto.FailResult("Debe especificar una empresa válida");
                }
            }

            client.Placa = client.Placa.ToUpper();
            bool actualizado = await _clientRepository.UpdateClient(client);
            string mensaje = !actualizado ? "No se pudo actualizar el registro" : "Actualizado correctamente";
            return ResultDto.SuccessResult(message: mensaje, statusCode: 400);
        }
        public async Task<ResultDto> DeleteClient(int id)
        {
            bool res = await _clientRepository.DeleteClient(id);
            if (res)
            {
                return ResultDto.SuccessResult(message:"Eliminado correctamente", statusCode: 200);
            }
            return ResultDto.FailResult(message: "Error eliminando el registro", statusCode:400);

        }
    }
}
