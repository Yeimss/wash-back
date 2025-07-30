//using core.in;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using data.Models.Context;

namespace data.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("cnxLocal");

            services.AddDbContext<LavaderoBDContext>(options =>
                options.UseSqlServer(connectionString));

            // Registrar implementaciones concretas de interfaces
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<INotificador, NotificadorSql>(); // otro ejemplo

            return services;
        }
    }
}

{
}
}
