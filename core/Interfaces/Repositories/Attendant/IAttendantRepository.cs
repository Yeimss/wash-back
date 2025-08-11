using core.Entities.Attendand;
using DTOs.Attendant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces.Repositories.Attendant
{
    public interface IAttendantRepository
    {
        Task<Encargado> Get(int id);
        Task<List<Encargado>> GetAll(int idEnterprice);
        Task<bool> Insert(AttendantDto attendant);
        Task<bool> Update(AttendantUpdateDto attendant);
        Task<bool> Delete(int id);
    }
}
