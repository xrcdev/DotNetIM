using im.common;
using Im.Common.component;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Forward.service.impl
{
    public class ForwradService : IForwradService
    {
        private RedisHerper _herper;
        private IHttpClientComponent _compent;
        public ForwradService(RedisHerper herper, IHttpClientComponent compent)
        {
            this._herper = herper;
            this._compent = compent;
        }
        public Task<bool> ForwradGroupChat(BaseMessage mes)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ForwradPriviteChat(BaseMessage mes)
        {

            //判断当前是否在线
            string host = null;
            if ((host = await _herper.GetValue<string>($"{mes.Reqid}_router")) == null)
            {
                return true;
            }
            string router = "";

            if (mes is MsgTextBody)
            {
                router = "sendTextMeg";
            }
            else if (mes is MsgStreamBody)
            {
                router = "sendStreamMeg";
            }
            if (!host.Contains("http://")) host = "http://" + host;
            
            var reslut=await _compent.Post<ApiResult<string>, BaseMessage>(host+"/"+router,mes);
          
            return reslut.Code == ApiResultCode.Success;
        }


    }
}
