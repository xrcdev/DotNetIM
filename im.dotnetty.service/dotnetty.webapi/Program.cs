using IM_server1.handle;
using IM_server1.server;
using IM_server1.Server;
using IM_server1.untils;
using Nacos.AspNetCore.V2;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace IM_server1
{
    public class Program
    {
        public static WebApplication _app { get; set; }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

 
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
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

            new AppBeanFactory(app.Services);

            IMserver? server=(IMserver?) app.Services.GetService(typeof(IMserver));
            
            server?.Start();


            app.MapControllers();
          
            app.Run();
        }
        public static void RegistService(WebApplicationBuilder app)
        {
            app.Services.AddSingleton<IMserver>();
         

            app.Services.AddTransient<IMServerInitializer>();
            app.Services.AddTransient<IMServerHandle>();
            app.Services.AddNacosAspNet(app.Configuration, "nacos");
            app.Services.AddHttpClient();
            app.Services.AddSingleton<IRemoteForwardService, RemoteForwardServiceImpl>();



        }
    }
}