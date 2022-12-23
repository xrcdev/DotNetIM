using im.sdk;
using im.sdk.entity;
using im.sdk.entity.Request;
using im.sdk.impl;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           var cfg= new EnvConfigure()
            {
                getwayAddr = "http://localhost",
                getwayPort = "5114"
            };

            IMClient client= new DefaultImClient(cfg);

            var req=new LoginRequest()
            {
                Useradmin = "adminoryuan",
                Password = "123456"
            };

            var res= await client.getLoginResponse(req);

            Console.WriteLine(res.IsSucess());

            Console.WriteLine(res.Message);


            Console.ReadLine();
        }
    }
}