using core.Entities.Usuario;
using core.Entities.Utils;
using core.Interfaces.Repositories.Auth;
using core.Interfaces.Services.IAuthService;
using DTOs.Auth;

namespace core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtGenerator _jwtGenerator;
        public AuthService(IAuthRepository authRepository, IJwtGenerator jwtGenerator)
        {
            _authRepository = authRepository;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<string?> Login(LoginUserDto usuario)
        {
            Usuario user = await _authRepository.GetUser(usuario.document);
            if (!user.password.Equals(StringHelper.ComputeSha256(usuario.password)))
            {
                return null;
            }

            string? token = _jwtGenerator.GenerateToken(user);
            return token;
        }
        public async Task<bool> CreateUser(UserDto user)
        {
            user.Password = StringHelper.ComputeSha256(user.Password);
            int createdUser = await _authRepository.InsertUser(user);
            if(createdUser == 0)
            {
                return false;
            }
            return true;
        }
    }
}
