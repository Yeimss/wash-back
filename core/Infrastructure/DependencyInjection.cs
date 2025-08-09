using core.Interfaces.Services.IAuthService;
using core.Interfaces.Services.IClientService;
using core.Interfaces.Services.IServicesService;
using core.Interfaces.Services.Washed;
using core.Services.Auth;
using core.Services.Client;
using core.Services.Services;
using core.Services.Washed;
using Microsoft.Extensions.DependencyInjection;
namespace core.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IServicesService, ServicesService>();
        services.AddScoped<IWashedService, WashedService>();
        

        return services;
    }
}