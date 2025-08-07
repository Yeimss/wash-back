using core.Entities.Cliente;
using core.Interfaces.Repositories.Client;
using core.Interfaces.Services.IClientService;
using DTOs.Client;
using DTOs.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

            if (rolClaim == null || empresaClaim == null)
            {
                return ResultDto.FailResult("No se pudo validar la identidad del usuarioNo se pudo validar la identidad del usuario");
            }
            int rol = int.Parse(rolClaim);
            int idEmpresaUsuario = int.Parse(empresaClaim);

            if (rol != 1)            {
                client.IdEnterprice = idEmpresaUsuario;
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
            string mensaje = cantAfectada > 0 ? "No se pudo insertar el registro" : "Insertado correctamente";
            return ResultDto.SuccessResult(message: mensaje, statusCode: 400);
        }
        public async Task<ResultDto> UpdateClient(ClientDto client, IEnumerable<Claim> claims)
        {

            var rolClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var empresaClaim = claims.FirstOrDefault(c => c.Type == "idEnterprice")?.Value;

            if (rolClaim == null || empresaClaim == null)
            {
                return ResultDto.FailResult("No se pudo validar la identidad del usuarioNo se pudo validar la identidad del usuario");
            }
            int rol = int.Parse(rolClaim);
            int idEmpresaUsuario = int.Parse(empresaClaim);

            if (rol != 1)
            {
                client.IdEnterprice = idEmpresaUsuario;
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
            string mensaje = cantAfectada > 0 ? "No se pudo insertar el registro" : "Insertado correctamente";
            return ResultDto.SuccessResult(message: mensaje, statusCode: 400);
        }
    }
}
