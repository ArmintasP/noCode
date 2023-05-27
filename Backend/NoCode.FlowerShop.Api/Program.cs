using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using NoCode.FlowerShop.Api;
using NoCode.FlowerShop.Api.Http;
using NoCode.FlowerShop.Api.Mappings;
using NoCode.FlowerShop.Application;
using NoCode.FlowerShop.Infrastructure;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddMappings()
        .AddSwagger();

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


    builder.Services.AddCors();
}

var crossOrigin = builder.Configuration.GetValue<string>("CrossOrigin")!;


var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.MapControllers();

    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(crossOrigin));
}

app.Run();
