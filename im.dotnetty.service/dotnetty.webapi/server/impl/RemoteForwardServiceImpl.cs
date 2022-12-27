using im.common;
using Im.Common.component;
using Microsoft.AspNetCore.Components.Routing;
using Nacos.V2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace dotnetty.webapi.server
{
    public class RemoteForwardServiceImpl : IRemoteForwardService
    {

        private IHttpClientComponent _component;
        private INacosNamingService _nacos;
        private ILogger<RemoteForwardServiceImpl> _logger;

        public RemoteForwardServiceImpl(ILogger<RemoteForwardServiceImpl> logger,
                                        IHttpClientComponent component,
                                        INacosNamingService nacos)
        {
            this._logger = logger;
            this._nacos = nacos;
            _component = component;
        }

        public async Task<bool> addRoute(long uid, string host)
        {

            _logger.LogInformation("addrouter {0} {1}", uid, host);
            var instance = await _nacos.SelectOneHealthyInstance("im-forward-service", "DEFAULT_GROUP");
            string remote = $"{instance.Ip}:{instance.Port}";
            if (!remote.Contains("http://")) remote = "http://" + remote;

            Console.WriteLine($"{remote}/Router?uid={uid}&host={host}");

            var res =await _component.Post<ApiResult<string>>($"{remote}/Router/Add?uid={uid}&host={host}");
              
             
            return res.Code==ApiResultCode.Success;

        }
    }
}
