using core.Interfaces.Repositories.Attendant;
using data.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories.Attendant
{
    public class AttendantRespository : IAttendantRepository
    {
        private readonly LavaderoBDContext _context;
        public AttendantRespository(LavaderoBDContext context)
        {
            _context = context;
        }
    }
}
