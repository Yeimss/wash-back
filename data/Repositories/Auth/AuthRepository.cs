using core.Interfaces.Auth;
using data.Models.Context;

namespace data.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LavaderoBDContext _context;
        public AuthRepository(LavaderoBDContext context)
        {
            _context = context;
        }
    }
}
