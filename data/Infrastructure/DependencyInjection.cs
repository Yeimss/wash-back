using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using data.Models.Context;
using core.Interfaces.Auth;
using data.Repositories.Auth;
using core.Interfaces.Services;
using data.Repositories.Services;

namespace data.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("cnxLocal");

            services.AddDbContext<LavaderoBDContext>(options =>
                options.UseSqlServer(connectionString));

            services.Configure<AuthSettings>(configuration.GetSection("Jwt"));


            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IServicesRepository, ServicesRepository>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();

            return services;
        }
    }
}