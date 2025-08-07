using core.Entities.Usuario;
using core.Entities.Utils;
using core.Interfaces.Repositories.Auth;
using core.Interfaces.Services.IAuthService;
using DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
