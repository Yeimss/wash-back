using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using data.Models.Context;
using data.Repositories.Auth;
using data.Repositories.Services;
using core.Interfaces.Repositories.Services;
using core.Interfaces.Repositories.Auth;
using core.Interfaces.Repositories.Client;
using data.Repositories.Client;
using core.Interfaces.Repositories.Washed;
using data.Repositories.Washed;

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
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IWashedRepository, WashedRepository>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();

            return services;
        }
    }
}