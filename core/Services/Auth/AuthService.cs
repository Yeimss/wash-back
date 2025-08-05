using core.Entities.Usuario;
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
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Usuario> GetUsuarioLogeado(LoginUserDto usuario)
        {
            Usuario user = await _authRepository.GetUser(usuario.document);
            if
        }
    }
}
