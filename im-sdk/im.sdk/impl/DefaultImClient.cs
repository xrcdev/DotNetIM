using im.common;
using im.sdk.entity;
using im.sdk.entity.Request;
using im.sdk.entity.Response;
using im.sdk.entity.Vo;
using im.sdk.untils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace im.sdk.impl
{
    public class DefaultImClient : IMClient
    {

        private EnvConfigure _cfg;
        private string host;
        public DefaultImClient(EnvConfigure config)
        {
            _cfg = config;
            host = string.Format($"{_cfg.getwayAddr}:{_cfg.getwayPort}" );
        }

        public async Task<ContsCtsListResponse> getContsCtsListResponse(ContsCtsListRequest req)
        {
            string route= GloableRouteConfig.GetOrDefaultValues("ContsCtsListRequest");

            var res= await HttpClientUtils.Get<ApiResult<List<ConCtsVo>>>($"{host}/{route}",req.token);

            return new ContsCtsListResponse(res.Data)
            {
                Code = res.Code,
                Message=res.Message,
            };
        }

        public async Task<LoginReponse> getLoginResponse(LoginRequest req)
        {
            string route = GloableRouteConfig.GetOrDefaultValues("LoginRequest");
            var res = await HttpClientUtils.Post<ApiResult<LoginVo>, LoginRequest>($"{host}{route}?admin={req.Useradmin}&password={req.Password}",req);

            return new LoginReponse(res.Data)
            {
                Code = res.Code,
                Message = res.Message,
            };

        }
    }
}
