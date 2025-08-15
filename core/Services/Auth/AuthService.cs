using core.Entities.Usuario;
using core.Entities.Utils;
using core.Interfaces.Repositories.Auth;
using core.Interfaces.Services.IAuthService;
using DTOs.Auth;
using DTOs.Result;

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

        public async Task<ResultDto?> Login(LoginUserDto usuario)
        {
            Usuario user = await _authRepository.GetUser(usuario.document);
            if (!user.password.Equals(StringHelper.ComputeSha256(usuario.password)))
            {
                return ResultDto.FailResult("No fue posible iniciar sesión", 401);
            }
            user.password = "metiche";
            string? token = _jwtGenerator.GenerateToken(user);
            return ResultDto.SuccessResult(data: new
            {
                token = token,
                user = user
            }, message: "Inicio de sesión exitoso", 200);
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
