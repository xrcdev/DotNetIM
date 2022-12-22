using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Channels;
using System.Net;
using DotNetty.Codecs.Protobuf;
using DotNetty.Codecs.Http;
using dotnetty.webapi.handle;
using dotnetty.webapi.cache;
using Im_Common;
using Google.Protobuf;
using System.Text;
using Nacos.V2;
using dotnetty.webapi.server;
using dotnetty.webapi.untils;
using im.common;

namespace dotnetty.webapi.Server
{

    public class IMserver
    {

        private String addr="";
               
        private int port;

        private IChannel chanle=null;

        
 
        private INacosNamingService _nacos;
        public IMserver(INacosNamingService nacos,
                        IConfiguration root
                        )
        {
          
            this._nacos = nacos;
            addr = root["imServer:bindAddr"];
            port = int.Parse(root["imServer:bindPort"]);
        }
        
        public async void Start()
        {
            var boosgroup = new MultithreadEventLoopGroup(3); //boss 线程
            var workgroup = new MultithreadEventLoopGroup(1); //work 线程
            ServerBootstrap bootstrap = new ServerBootstrap();
            bootstrap.
               Group(boosgroup, workgroup)
                .Channel<TcpServerSocketChannel>()
                .Option(ChannelOption.SoReuseport, true)
                .Option(ChannelOption.TcpNodelay, true)
               .Option(ChannelOption.SoBacklog, 1024)
               .Option(ChannelOption.SoKeepalive, true)
               .ChildHandler(AppBeanFactory.getBean<IMServerInitializer>());

            Console.WriteLine($"[Sharpdis] Server start [{addr}:{port}]");

            this.chanle = await bootstrap.BindAsync(IPAddress.Parse(addr), port);
            await _nacos.RegisterInstance("im-server", "DEFAULT_GROUP", addr, port);

            
        }

        /// <summary>
        /// 发送消息给指定用户
        /// </summary>
        /// <param name="req">用户标识</param>
        public void SendMeg(BaseMessage req)
        {

           var chanle= SessionCache.GetChannel(req.Reqid);

           var request= new IMRequest()
            {
                MessageId = req.Reqid,
                Type = (int)MsgType.MSG
            };
          
            if(req is MsgTextBody)
            {
                var obj= (MsgTextBody)req;

                request.Body =ByteString.CopyFrom(Encoding.UTF8.GetBytes(obj.Body));
            }else if(req is MsgStreamBody)
            {
                var obj = (MsgStreamBody)req;
                using var memoryStrem= new MemoryStream();

                memoryStrem.WriteTo(obj.Body);
                
                request.Body = ByteString.CopyFrom(memoryStrem.ToArray());
            }
                         
            chanle?.WriteAndFlushAsync(request);
        }
    }
}
