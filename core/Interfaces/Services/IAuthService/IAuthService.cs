using core.Entities.Usuario;
using DTOs.Auth;

namespace core.Interfaces.Services.IAuthService
{
    public interface IAuthService
    {
        Task<string?> Login(LoginUserDto usuario); 
    }
}
