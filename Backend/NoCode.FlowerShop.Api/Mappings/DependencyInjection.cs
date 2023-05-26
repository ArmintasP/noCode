using Mapster;
using MapsterMapper;
using System.Reflection;

namespace NoCode.FlowerShop.Api.Mappings;

public static class SwaggerInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}
