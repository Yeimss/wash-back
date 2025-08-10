using core.Interfaces.Repositories.Attendant;
using core.Interfaces.Services.Attendant;

namespace core.Services.Attendant
{
    public class AttendantService : IAttendantService
    {
        private readonly IAttendantRepository _attendantRepository;
        public AttendantService(IAttendantRepository attendantRepository)
        {
            _attendantRepository = attendantRepository;
        }

    }
}
