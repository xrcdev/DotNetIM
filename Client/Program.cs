using im.sdk.client;
using im.sdk.client.impl;
using im.sdk.entity;
using im.sdk.entity.Request;
using im.sdk.impl;
using System.Text;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var cfg = new EnvConfigure()
            {
                getwayAddr = "http://localhost",
                getwayPort = "5114"
            };

            IMClient client = new DefaultImClient(cfg);

            var req = new LoginRequest()
            {
                Useradmin = "adminoryuan",
                Password = "123456"
            };

            var res = await client.getLoginResponse(req);

            Console.WriteLine(res.IsSucess());

            Console.WriteLine(res.Message);

            var userinfo = res.getLoginVo();

            var respon = await client.GetImServerAddrResponse(new ImServerAddrRequest()
            {
                token = userinfo.Token
            });

            Console.WriteLine(respon.addr);


            var pushclient= PushClientFactory.GetPushClient(PushClientType.Tcp, new PushRequest()
            {
                token = "3e655327ab27c73a439a6aec805ea8",
                userTag =long.Parse("16110335724438528") 
            }, "");

            AbstPushClient.OnReciveEvent += AbstPushClient_OnReciveEvent;
            Console.ReadLine();
        }

        private static void AbstPushClient_OnReciveEvent(IMRequest obj)
        {
            Console.WriteLine("收到消息:"+Encoding.UTF8.GetString(obj.Body.ToArray()));
        }
    }
}