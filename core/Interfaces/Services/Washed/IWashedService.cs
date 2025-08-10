using core.Entities.Wash;
using DTOs.Result;
using DTOs.Washed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces.Services.Washed
{
    public interface IWashedService
    {
        Task<ResultDto> Get(int id, IEnumerable<Claim> claims);
        Task<ResultDto> GetAll(WashedFiltersDto filters, IEnumerable<Claim> claims);
        Task<ResultDto> Insert(WashedDto wash, IEnumerable<Claim> claims);
        Task<ResultDto> Update(WashedUpdateDto wash, IEnumerable<Claim> claims);
        Task<ResultDto> Delete(int id, IEnumerable<Claim> claims);
    }
}
