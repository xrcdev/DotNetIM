using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Codecs.Protobuf;
using im.sdk.client.impl.handle;
using Im_Common;
using Google.Protobuf;
using im.sdk.untils;
using im.sdk.core;
using im.sdk.entity;

namespace im.sdk.client.impl
{
    internal class TcpPushClient : AbstPushClient
    {

        private IChannel _channel;
        public TcpPushClient(PushConfigure request, string remoteAddr) : base(request, remoteAddr)
        {

        }

        public override async Task ConnectAsync(string ImAddr)
        {
            var group = new MultithreadEventLoopGroup();
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
                    pipelin.AddLast(new TcpPushHandler());
                }));

            this._channel = await bootstrap.ConnectAsync("127.0.0.1", 9990);

            await Login(new IMRequest()
            {
                Body=ByteString.CopyFrom(this._request.token.ToArray()),
                MessageId=this._request.userTag,
                Type=(int)MsgType.LOGIN
            });
        }

        protected override async Task Login(IMRequest req)
        {
           await this._channel.WriteAndFlushAsync(req);
        }
    }
}
