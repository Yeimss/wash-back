using core.Interfaces.Services.IAuthService;
using core.Interfaces.Services.IClientService;
using core.Services.Auth;
using core.Services.Client;
using Microsoft.Extensions.DependencyInjection;
namespace core.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClientService, ClientService>();
        

        return services;
    }
}