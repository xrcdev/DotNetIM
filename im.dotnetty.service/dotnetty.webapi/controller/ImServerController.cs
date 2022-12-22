using im.common;
using dotnetty.webapi.Server;
using Microsoft.AspNetCore.Mvc;

namespace dotnetty.webapi.Controller
{
    [ApiController]   
    public class ImServerController
    {

        private IMserver _server;
        public ImServerController(IMserver server)
        {
            this._server = server;
        }

        [HttpPost]
        [Route("/sendTextMeg")]
        public ApiResult<String> SendStreamMeg([FromBody] MsgTextBody body)
        {
            _server.SendMeg(body);

            var res = new ApiResult<String>()
            {
                Code = ApiResultCode.Success,
                Message = "发送成功"
            };

            return res;
        }


        [HttpPost]
        [Route("/sendStreamMeg")]
        public ApiResult<string> SendTextMeg([FromBody] MsgStreamBody body)
        {
            _server.SendMeg(body);

            var res = new ApiResult<String>()
            {
                Code = ApiResultCode.Success,
                Message = "发送成功"
            };

            return res;
        }
    }
}
