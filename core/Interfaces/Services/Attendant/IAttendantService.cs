using DTOs.Attendant;
using DTOs.Result;
using System.Security.Claims;

namespace core.Interfaces.Services.Attendant
{
    public interface IAttendantService
    {
        Task<ResultDto> GetAll(IEnumerable<Claim> claims, int? idEnterprice);
        Task<ResultDto> Insert(AttendantDto attendant, IEnumerable<Claim> claims);
        Task<ResultDto> Update(AttendantUpdateDto attendant, IEnumerable<Claim> claims);
        Task<ResultDto> Delete(int id, IEnumerable<Claim> claims);
    }
}
