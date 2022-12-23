using im.common;
using Im.Common.component;
using Im.Common.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Nacos.V2;
using Nacos.V2.Utils;
using Newtonsoft.Json;
using Ocelot.Provider.Nacos;
using System.Net.Mime;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace geteway.Auth
{
    public class CustomAuthenticationMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly IHttpClientComponent _component;
        private readonly INacosNamingService _nacos;
        public CustomAuthenticationMiddleware(
                                                INacosNamingService nacos,
                                                IHttpClientComponent component,
                                                RequestDelegate next)
        {
            _nacos = nacos;
            _component = component; 
            _next = next ?? throw new ArgumentNullException(nameof(next));

        }

        public async Task Invoke(HttpContext context)
        {

            var failtResult = new ApiResult<string>()
            {
                Code = ApiResultCode.Failed,
                Message = "请先登录"
            };
            if (context.Request.Path.Value.Equals("/system/Login"))
            {
               await  _next(context);
                return;
            } 
               
            if ( !context.Request.Headers.TryGetValue("Authorization", out var authorization))
            {
                 
                await context.Response.WriteAsJsonAsync(failtResult);
                return;
            }

            var instance = await _nacos.SelectOneHealthyInstance("im-api-service", "DEFAULT_GROUP");
            string remote = $"{instance.Ip}:{instance.Port}";
            if (!remote.Contains("http://")) remote = "http://" + remote;

            var res =await _component.Get<ApiResult<TokenVo>>(string.Format($"{remote}/PaserToken?token={authorization}"));

            if (res.Code == ApiResultCode.Failed)
            {
                await context.Response.WriteAsJsonAsync(failtResult);
                return;
            }
            else
            {
               context.Request.Headers["userinfo"]= JsonConvert.SerializeObject(res.Data);
            }


            await _next(context);
        }

    }
}
