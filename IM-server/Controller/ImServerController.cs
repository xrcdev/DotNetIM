using IM_server1.Entity;
using IM_server1.Entity.Result;
using IM_server1.Server;
using Microsoft.AspNetCore.Mvc;

namespace IM_server1.Controller
{
    [ApiController]   
    public class ImServerController
    {

        private imServer server;
        public ImServerController(imServer server)
        {
            this.server = server;
        }

        [HttpPost]
        [Route("/SendTextMeg")]
        public ApiResult<String> SendStreamMeg([FromBody] MsgTextBody body)
        {
            server.SendMeg(body);

            var res = new ApiResult<String>()
            {
                Code = ApiResultCode.Success,
                Message = "登录成功"
            };

            return res;
        }


        [HttpPost]
        [Route("/SendTextMeg")]
        public ApiResult<String> SendTextMeg([FromBody] MsgStreamBody body)
        {
            server.SendMeg(body);

            var res = new ApiResult<String>()
            {
                Code = ApiResultCode.Success,
                Message = "登录成功"
            };

            return res;
        }
    }
}
