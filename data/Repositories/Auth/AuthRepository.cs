using core.Entities.Usuario;
using core.Entities.Utils;
using core.Interfaces.Repositories.Auth;
using data.Models.Context;
using DTOs.Auth;
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
            try
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
                        rol = usuario.idRolNavigation?.rol,
                        password = usuario.PasswordHash,
                        phone = usuario.phone,
                        email = usuario.email
                    };
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> InsertUser(UserDto user)
        {
            try
            {
                tbl_user usuario = new tbl_user
                {
                    document = user.Document,
                    name = user.Name,
                    email = user.Email,
                    phone = user.Phone,
                    PasswordHash = user.Password,
                    idEnterprice = user.idEnterprice,
                    idRol = user.idRol,
                };
                _context.tbl_users.Add(usuario);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
