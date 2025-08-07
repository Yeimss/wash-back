using core.Entities.Usuario;

namespace core.Interfaces.Repositories.Auth
{
    public interface IJwtGenerator
    {
        string GenerateToken(Usuario user);
    }
}
