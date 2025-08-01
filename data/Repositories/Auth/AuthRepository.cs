using core.Entities.Usuario;
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
        public async Task<Usuario> getUser()
        {
            return new Usuario();
        }
    }
}
