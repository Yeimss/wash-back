using core.Entities.Usuario;

namespace core.Interfaces.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<Usuario> GetUser(string documento);
    }
}
