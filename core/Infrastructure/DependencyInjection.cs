using Microsoft.Extensions.DependencyInjection;
namespace core.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        //services.AddScoped<INotificador, Notificador>();
        

        return services;
    }
}