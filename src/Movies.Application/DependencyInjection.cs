using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Common.Behaviors;

namespace Movies.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: false);
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
