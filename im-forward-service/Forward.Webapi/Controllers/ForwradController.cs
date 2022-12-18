
using Forward.service;
using im.common;
using Microsoft.AspNetCore.Mvc;

namespace Forward.Webapi.Controllers
{
    /// <summary>
    /// 用来做转发
    /// </summary>
    [ApiController]
    [Route("/Chat")]
    public class ForwradController
    {
        private IForwradService _service;

        public ForwradController(IForwradService service)
        {
            this._service = service;
        }

        /// <summary>
        /// 私聊发送文本消息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/private/SendTxtMeg")]
        public async Task<ApiResult<string>> PrivateChat([FromBody] MsgTextBody body)
        {
            if (!await _service.ForwradPriviteChat(body))
            {
                return new ApiResult<string>()
                {
                    Code = ApiResultCode.Failed,
                    Message = "发送失败请稍后再试！"
                };
            }
            return new ApiResult<string>()
            {
                Code = ApiResultCode.Success,
                Message = "发送成功！"
            };
        }

    }
}
