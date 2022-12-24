using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.client.impl.handle
{
    internal class TcpPushHandler : SimpleChannelInboundHandler<IMRequest>
    {
        protected override void ChannelRead0(IChannelHandlerContext ctx, IMRequest msg)
        {
            AbstPushClient.Push(msg);
        }
    }
}
