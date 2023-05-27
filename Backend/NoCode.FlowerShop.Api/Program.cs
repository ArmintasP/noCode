using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using NoCode.FlowerShop.Api;
using NoCode.FlowerShop.Api.Http;
using NoCode.FlowerShop.Api.Mappings;
using NoCode.FlowerShop.Application;
using NoCode.FlowerShop.Infrastructure;
using System.Globalization;
using NoCode.FlowerShop.Application.Common.Interfaces.Interceptors;
using NoCode.FlowerShop.Infrastructure.ActionFilters;
using NoCode.FlowerShop.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddMappings()
        .AddSwagger();

    builder.Services.AddSingleton<IActionLogService, ActionLogService>();
    
    builder.Services.AddSingleton<ProblemDetailsFactory, FlowerShopProblemDetailsFactory>();
    builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            var dateConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ssZ"
            };

            options.SerializerSettings.Converters.Add(dateConverter);
            options.SerializerSettings.Culture = new CultureInfo("en-IE");
            options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        });
    
    builder.Services.AddControllersWithViews(options =>
    {
        options.Filters.Add<LogActionFilter>();
    });
    
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });
}

var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.MapControllers();

    app.UseCors("CorsPolicy");
}

app.Run();
