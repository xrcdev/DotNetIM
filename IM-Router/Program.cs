using IM_Router.Dao;
using IM_Router.service;
using IM_Router.service.impl;
using IM_Router.Service;
using IM_Router.Service.impl;
using IM_Router.untils;
using Microsoft.Extensions.Configuration;
using Nacos.AspNetCore.V2;
using Nacos.V2.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace IM_Router
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            
            if (false) {
                var gender = new CodeGenerate();

                gender.Start();
                return;
            }


            var builder = WebApplication.CreateBuilder(args);

 
            builder.Services.AddControllers().
                ConfigureApiBehaviorOptions(option =>
            {
                
            });

             builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            SugarClientUntils.Init(builder.Configuration["mysql:constr"]);
            RegistService(builder);

            var redisConfiguration = builder.Configuration.GetSection("Redis").Get<RedisConfiguration>();

            builder.Services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

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
            app.Services.AddSingleton<IUserService, UserService>();
            app.Services.AddSingleton<TokenManager>();
            app.Services.AddHttpClient();
            app.Services.AddSingleton<RedisHerper>();
            app.Services.AddSingleton<IForwradService, ForwradService>();
            app.Services.AddSingleton<IRouteService, RouteService>();
            app.Services.AddNacosAspNet(app.Configuration,"nacos");

        }
    }
}