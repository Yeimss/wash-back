using core.Entities.Cliente;
using DTOs.Client;
using DTOs.Result;
using System.Security.Claims;

namespace core.Interfaces.Services.IClientService
{
    public interface IClientService
    {
        Task<ResultDto> GetClient(ClientFilterDto clientFilters, IEnumerable<Claim> claims);
        Task<ResultDto> InsertClient(ClientDto client, IEnumerable<Claim> claims);
        Task<ResultDto> UpdateClient(ClientUpdateDto client, IEnumerable<Claim> claims);
    }
}
