using Im.Common.component;
using dotnetty.webapi.handle;
using dotnetty.webapi.server;
using dotnetty.webapi.Server;
using dotnetty.webapi.untils;
using Nacos.AspNetCore.V2;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using Google.Protobuf.WellKnownTypes;

namespace dotnetty.webapi
{
    public static class Program
    {
        public static WebApplication _app { get; set; }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

 
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.RegistService();

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


            app.StartImServer();

            app.MapControllers();
          
            app.Run();
        }
        public static void StartImServer(this WebApplication app)
        {
            IMserver? server = (IMserver?)app.Services.GetRequiredService(typeof(IMserver));

            server?.Start();
        }
        public static void RegistService(this WebApplicationBuilder app)
        {
            app.Services.AddSingleton<IMserver>(); 
            app.Services.AddTransient<IMServerInitializer>();
            app.Services.AddTransient<IMServerHandle>();
            app.Services.AddNacosAspNet(app.Configuration, "nacos");
            app.Services.AddHttpClient();
            app.Services.AddSingleton<IRemoteForwardService, RemoteForwardServiceImpl>();

            app.Services.AddSingleton<IHttpClientComponent, HttpClientComponent>();


        }
    }
}