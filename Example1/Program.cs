using System.Net.Sockets;
using System.Net;
using Microsoft.AspNetCore.DataProtection;
using IM_server1.Entity;
using Im_Common;
using System.Text;
using Google.Protobuf;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Channels;
using DotNetty.Handlers.Logging;
using DotNetty.Codecs.Protobuf;
using Microsoft.AspNetCore.Components.Routing;
using Newtonsoft.Json.Linq;
using ProtoBuf.Serializers;
using Newtonsoft.Json;

namespace Example1
{
    internal class Program
    {
        class Handle: SimpleChannelInboundHandler<IMRequest>
        {
            protected override void ChannelRead0(IChannelHandlerContext ctx, IMRequest msg)
            {

                Console.WriteLine(Encoding.UTF8.GetString(msg.Body.ToArray()));
             
            }
        }
        static async Task Main(string[] args)
        {




            
            var group = new MultithreadEventLoopGroup();

            String host = "127.0.0.1"; int port = 9990;
            var bootstrap = new Bootstrap();
            bootstrap
                .Group(group)
                .Channel<TcpSocketChannel>()
                .Option(ChannelOption.TcpNodelay, true)
                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipelin = channel.Pipeline;

                    pipelin.AddLast(new ProtobufVarint32LengthFieldPrepender());
                    pipelin.AddLast(new ProtobufEncoder());
                    pipelin.AddLast(new ProtobufVarint32FrameDecoder());
                    pipelin.AddLast(new ProtobufDecoder(IMRequest.Parser));
                    pipelin.AddLast(new Handle());
                 }));

            IChannel bootstrapChannel = await bootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse(host),port));


            var r= new IMRequest() { Type = (int)MsgType.LOGIN, 
                              MessageId = 16110335724438528, 
                              Body =ByteString.CopyFrom(Encoding.UTF8.GetBytes("hello")) 
            };

            await bootstrapChannel.WriteAndFlushAsync(r);

            Console.ReadLine();

            await bootstrapChannel.CloseAsync();

        }
    }
}