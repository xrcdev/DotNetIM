using im.sdk.client.impl;
using im.sdk.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.core
{
    public static class PushClientFactory
    {

        public static AbstPushClient GetPushClient(PushClientType type, PushConfigure req, string remoteAddr)
        {
            if (type == PushClientType.Tcp)
                return new TcpPushClient(req, remoteAddr);
            return null;
        }
    }
}
