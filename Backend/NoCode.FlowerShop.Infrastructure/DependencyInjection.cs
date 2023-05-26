using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using NoCode.FlowerShop.Application.Common.Interfaces.Clock;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Infrastructure;
using NoCode.FlowerShop.Infrastructure.Authentication;
using NoCode.FlowerShop.Infrastructure.Persistence;
using NoCode.FlowerShop.Infrastructure.Persistence.Repositories;
using NoCode.FlowerShop.Infrastructure.Time;
using System.Text;

namespace NoCode.FlowerShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddPersistence(configuration);
        services.AddAuthentication(configuration);

        services.Configure<PasswordProviderSettings>(configuration.GetSection("PasswordProviderSettings"));
        services.AddSingleton<IPasswordProvider, PasswordProvider>();

        services.AddSingleton<IClock, Clock>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {
        var sqlConnectionString = configuration.GetValue<string>("SqlConnectionString");

        services.AddDbContext<FlowerShopDbContext>(options =>
            options.UseSqlite(sqlConnectionString));

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAdministratorRepository, AdministratorRepository>();
        services.AddScoped<IFlowerRepository, FlowerRepository>();
        services.AddScoped<IFlowerArrangementRepository, FlowerArrangementRepository>();
        services.AddScoped<IFlowerArrangementCategoryRepository, FlowerArrangementCategoryRepository>();
        services.AddScoped<ICartRepository, CartRepository>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind("JwtSettings", jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }
}
