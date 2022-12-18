using DotNetty.Transport.Channels;
using Im_Common;
using IM_server1.cache;
using IM_server1.server;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace IM_server1.handle
{
   
    public class IMServerHandle : SimpleChannelInboundHandler<IMRequest>
    {

        private IRemoteForwardService _remote;
        private ILogger<IMServerHandle> _logger;
        public IMServerHandle(
                                ILogger<IMServerHandle> logger,
                                IRemoteForwardService remote)
        {
            this._logger=logger;
            this._remote = remote;
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
            }
             
        }
    }
}
