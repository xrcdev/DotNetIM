using DotNetty.Transport.Channels;
using Im_Common;
using IM_server1.cache;
using System.Text;

namespace IM_server1.handle
{
    public class imServerHandle : SimpleChannelInboundHandler<IMRequest>
    {
        
        protected override void ChannelRead0(IChannelHandlerContext ctx, IMRequest msg)
        {
                
            //登录消息
            if (msg.Type ==(uint)MsgType.LOGIN)
            {
                
                SessionCache.Put(msg.MessageId,ctx.Channel);
                SessionCache.SaveSession(msg.MessageId,Encoding.UTF8.GetString(msg.Body.ToByteArray()));
            }
             
        }
    }
}
