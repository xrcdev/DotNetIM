using Forward.service;
using Forward.service.impl;
using Nacos.AspNetCore.V2;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace Forward.Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var redisConfiguration = builder.Configuration.GetSection("Redis").Get<RedisConfiguration>();

            builder.Services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

            RegistService(builder);
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
        public static void RegistService(WebApplicationBuilder app)
        {
            app.Services.AddSingleton<IRouteService, RouteService>();
            app.Services.AddSingleton<IForwradService, ForwradService>();
            app.Services.AddHttpClient();
            app.Services.AddSingleton<RedisHerper>();
            app.Services.AddNacosAspNet(app.Configuration, "nacos");

        }
    }
}