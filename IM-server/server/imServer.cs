using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Channels;
using System.Net;
using DotNetty.Codecs.Protobuf;
using DotNetty.Codecs.Http;
using IM_server1.Entity;
using IM_server1.handle;
using IM_server1.cache;

namespace IM_server1.Server
{
    public class imServer
    {

        private String addr="1";
               
        private int port;

        private IChannel chanle=null;
        private imServerHandle handle=null;
        
        public imServer(IConfiguration  root,imServerHandle handle)
        {
            this.handle = handle;
            addr = root["imServer:bindAddr"];
            port = int.Parse(root["imServer:bindPort"]);
            Start();
        }
        private async void Start()
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
                .ChildHandler(new ActionChannelInitializer<ISocketChannel>(chanle =>
                {   
                    var pipelin = chanle.Pipeline;

             
                    pipelin.AddLast(new ProtobufVarint32LengthFieldPrepender());
                    pipelin.AddLast(new ProtobufEncoder());
                    pipelin.AddLast(new ProtobufVarint32FrameDecoder());
                    pipelin.AddLast(new ProtobufDecoder(IMRequest.Parser));
                        
                    pipelin.AddLast(this.handle);

                }));

            Console.WriteLine($"[Sharpdis] Server start [{addr}:{port}]");

            this.chanle = await bootstrap.BindAsync(addr, port);

        }

        public void SendMeg(BaseMessage req)
        {

            var chanle= SessionCache.GetChannel(req.Reqid);
 
           
        
        }
    }
}
