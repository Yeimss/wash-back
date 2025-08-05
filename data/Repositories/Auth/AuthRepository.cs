using core.Entities.Usuario;
using core.Interfaces.Repositories.Auth;
using data.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace data.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LavaderoBDContext _context;
        public AuthRepository(LavaderoBDContext context)
        {
            _context = context;
        }
        public async Task<Usuario> GetUser(string documento)
        {
            tbl_user usuario = await _context
                .tbl_users
                .Include(u => u.idRolNavigation)
                .Include(u => u.idEnterpriceNavigation)
                .FirstOrDefaultAsync(u => u.document.Equals(documento));

            if (usuario != null)
            {
                return new Usuario
                {
                    id = usuario.id,
                    name = usuario.name,
                    document = documento,
                    enterprice = usuario.idEnterpriceNavigation?.enterprice,
                    idEnterprice = usuario.idEnterprice,
                    idRol = usuario.idRol,
                    rol = usuario.idRolNavigation?.rol
                };
            }
            return null;
        }
    }
}
