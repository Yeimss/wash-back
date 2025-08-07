using core.Entities.Usuario;
using core.Interfaces.Repositories.Auth;
using data.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace data.Repositories.Auth
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly AuthSettings _settings;
        public JwtGenerator(IOptions<AuthSettings> settings)
        {
            _settings = settings.Value;
        }
        public string GenerateToken(Usuario user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
            new Claim(ClaimTypes.Dns, user.document!),
            new Claim(ClaimTypes.Role, user.idRol.ToString()!),
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.MobilePhone, user.phone),
            new Claim("empresa", user.enterprice),
            new Claim("idEmpresa", user.idEnterprice.ToString()),
            new Claim("rolName", user.rol),
            new Claim("EmpresaImage", user.rol)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
