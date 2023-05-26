using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NoCode.FlowerShop.Application.Common.Behaviors;
using System.Reflection;

namespace NoCode.FlowerShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        return services;
    }
}
