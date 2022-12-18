using Im_Common.Entity;
using Microsoft.AspNetCore.Components.Routing;
using Nacos.V2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IM_server1.server.新文件夹
{
    public class RemoteForwardServiceImpl : IRemoteForwardService
    {

        private IHttpClientFactory _factory;
        private INacosNamingService _nacos;
        private ILogger<RemoteForwardServiceImpl> _logger;

        public RemoteForwardServiceImpl(ILogger<RemoteForwardServiceImpl> logger,
                                        IHttpClientFactory factory,
                                        INacosNamingService nacos)
        {
            this._logger = logger;
            this._nacos = nacos;
            _factory = factory;
        }

        public async Task<bool> addRoute(long uid, string host)
        {

             
            _logger.LogInformation("addrouter {0} {1}", uid, host);
            var instance = await _nacos.SelectOneHealthyInstance("im-forward", "DEFAULT_GROUP");
            string remote = $"{instance.Ip}:{instance.Port}";
            if (!remote.Contains("http://")) remote = "http://" + remote;

            var request = new HttpRequestMessage(HttpMethod.Post, $"{remote}/addRoute?uid={uid}&host={host}");


            var client = _factory.CreateClient();
            
            var response = await client.SendAsync(request);

            var res = await response.Content.ReadAsStringAsync();
            var apiresult= JsonConvert.DeserializeObject<ApiResult<string>>(res);

       
            return apiresult.Code==ApiResultCode.Success;

        }
    }
}
