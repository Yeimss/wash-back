using core.Entities.Wash;
using DTOs.Washed;

namespace core.Interfaces.Repositories.Washed
{
    public interface IWashedRepository
    {
        Task<List<Wash>> GetWashed(WashedFiltersDto filters);
        Task<Wash> GetWash(int id);
        Task<bool> Insert(WashedDto wash);
        Task<bool> UpdateWash(WashedUpdateDto wash);
        Task<bool> DeleteWashed(int id);
    }
}
