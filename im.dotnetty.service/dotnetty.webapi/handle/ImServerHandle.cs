using DotNetty.Transport.Channels;
using Im_Common;
using dotnetty.webapi.cache;
using dotnetty.webapi.server;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Google.Protobuf;
using DotNetty.Handlers.Timeout;

namespace dotnetty.webapi.handle
{
   
    public class IMServerHandle : SimpleChannelInboundHandler<IMRequest>
    {
        public override bool IsSharable => true;

        private IRemoteForwardService _remote;
        private ILogger<IMServerHandle> _logger;
        public IMServerHandle(
                                ILogger<IMServerHandle> logger,
                                IRemoteForwardService remote)
        {
            this._logger=logger;
            this._remote = remote;
        }
        public override void ChannelInactive(IChannelHandlerContext context)
        {
            
            //客户端断开
            base.ChannelInactive(context);
        }
        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            if (evt is IdleStateEvent eventState)
            {
                if (eventState.State == IdleState.ReaderIdle)
                {
                     //读超时

                }
            }
        }
        protected override async void ChannelRead0(IChannelHandlerContext ctx, IMRequest msg)
        {
                
            //登录消息
            if (msg.Type ==(uint)MsgType.LOGIN)
            {
                
                SessionCache.Put(msg.MessageId,ctx.Channel);
                SessionCache.SaveSession(msg.MessageId,Encoding.UTF8.GetString(msg.Body.ToByteArray()));
              
           
               bool res=  await _remote.addRoute(msg.MessageId, "127.0.0.1:8881");

                _logger.LogInformation(res?"路由添加成功":"失败");

                await ctx.WriteAndFlushAsync(new IMRequest()
                {
                    Body = ByteString.CopyFrom(Encoding.UTF8.GetBytes("登录成功"))
                });
            }
            else if(msg.Type==(int)MsgType.PING)
            {
                await ctx.WriteAndFlushAsync(new IMResponse()
                {
                    Type=(int)MsgType.PONG
                });
            }
             
        }
    }
}
