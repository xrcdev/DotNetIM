using im.sdk.entity.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace im.sdk.client.impl
{
    public abstract class AbstPushClient: IPushClient
    {
        protected  PushRequest _request;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag">用户唯一标识</param>
        /// <param name="token">令牌</param>
        public AbstPushClient(PushRequest request,string remoteAddr)
        {
            this._request = request;

            ConnectAsync(remoteAddr);
        }

        public static event Action<IMRequest> OnReciveEvent;

        public static void Push(IMRequest req)
        {
            OnReciveEvent(req);
        }

        /// <summary>
        /// 链接远程服务器
        /// </summary>
        /// <param name="ImAddr"></param>
        public abstract Task ConnectAsync(string ImAddr);


        /// <summary>
        /// 链接远程服务器
        /// </summary>
        /// <param name="ImAddr"></param>
        protected abstract Task Login(IMRequest req);
    }
}
