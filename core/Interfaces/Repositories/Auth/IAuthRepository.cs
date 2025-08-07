using core.Entities.Usuario;
using DTOs.Auth;

namespace core.Interfaces.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<Usuario> GetUser(string documento);
        Task<int> InsertUser(UserDto usuario);
    }
}
