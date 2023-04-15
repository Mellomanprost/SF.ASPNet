using Home.Api.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation.AspNetCore;
using HomeApi.Contracts.Validation;

namespace Home.Api
{
    public class Program
    {
        /// <summary>
        /// �������� ������������ �� ����� Json
        /// </summary>
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddJsonFile("HomeOptions.json").Build();

        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<AddDeviceRequestValidator>());
            // ��������� ����� ������
            builder.Services.Configure<HomeOptions>(Configuration);
            builder.Services.Configure<HomeOptions>(opt => { opt.Area = 120; });
            // ���������� �����������
            var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            builder.Services.AddAutoMapper(assembly);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {c.SwaggerDoc("v1", new OpenApiInfo {Title = "HomeApi", Version = "v1"});});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}