using core.Interfaces.Services;
using data.Models.Context;

namespace data.Repositories.Services
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly LavaderoBDContext _context;
        public ServicesRepository(LavaderoBDContext context)
        {
            _context = context;
        }
        
    }
}
