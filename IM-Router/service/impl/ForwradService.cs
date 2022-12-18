using IM_Router.untils;
using IM_server1.Entity;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Im_Common.Entity;

namespace IM_Router.service.impl
{
    public class ForwradService : IForwradService
    {
        private RedisHerper _herper;
        private IHttpClientFactory _factory;
        public ForwradService(RedisHerper herper, IHttpClientFactory factory)
        {
            this._herper = herper;
            this._factory = factory;   
        }
        public Task<bool> ForwradGroupChat(BaseMessage mes)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ForwradPriviteChat(BaseMessage mes)
        {

            //判断当前是否在线
            string host=null;
            if((host=await _herper.GetValue<string>($"{mes.Reqid}_router")) == null)
            {
                return true;
            }

            
            string router = "";
            string body = "";
            if (mes is MsgTextBody)
            {
                router = "sendTextMeg";

                body = JsonConvert.SerializeObject((MsgTextBody)mes); 
                
            }
            else if (mes is MsgStreamBody)
            {
                router = "sendStreamMeg";
            }
            if (!host.Contains("http://")) host = "http://" + host;
             
            var request = new HttpRequestMessage(HttpMethod.Post, $"{host}/{router}");

            request.Content = new StringContent(body);
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var client = _factory.CreateClient();


            var response = await client.SendAsync(request);

            var apiresult = JsonConvert.DeserializeObject<ApiResult<string>>(await response.Content.ReadAsStringAsync());


            return apiresult.Code == ApiResultCode.Success;
        }

       
    }
}
