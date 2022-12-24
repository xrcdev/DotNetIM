using im.sdk.entity.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.client.impl
{
    public static class PushClientFactory
    {

        public static AbstPushClient GetPushClient(PushClientType type,PushRequest req,string remoteAddr)
        {
            if (type == PushClientType.Tcp)
                return new TcpPushClient(req,remoteAddr);
            return null;
        }
    }
}
