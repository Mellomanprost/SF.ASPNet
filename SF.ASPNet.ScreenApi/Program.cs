using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using ScreenApi.Contracts.Models;
using ScreenApi.Contracts.Validators;
using SF.ASPNet.ScreenApi.Configuration;

namespace SF.ASPNet.ScreenApi
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddJsonFile("ScreenApiOptions.json")
            .Build();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<AddDiskRequestValidator>());
            builder.Services.Configure<ScreenApiOptions>(Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {c.SwaggerDoc("v1", new OpenApiInfo(){Title = "ScreenApi", Version = "v1"});});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScreenApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}