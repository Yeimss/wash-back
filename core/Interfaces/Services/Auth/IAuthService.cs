using core.Entities.Usuario;
using DTOs.Auth;
using DTOs.Result;

namespace core.Interfaces.Services.IAuthService
{
    public interface IAuthService
    {
        Task<ResultDto?> Login(LoginUserDto usuario);
        Task<bool> CreateUser(UserDto user); 
    }
}
