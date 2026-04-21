using Microsoft.Extensions.DependencyInjection;
using SaasStarter.Application.Abstractions;
using SaasStarter.Infrastructure.Persistence;

namespace SaasStarter.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
        return services;
    }
}
