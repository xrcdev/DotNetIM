using Im_Common.Entity;
using IM_Router.service;
using IM_server1.Entity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IM_Router.controller
{
    /// <summary>
    /// 用来做转发
    /// </summary>
    [ApiController]
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
        [HttpPost("PrivateChat/SendTxtMeg")]
        public async Task<ApiResult<string>> PrivateChat([FromBody] MsgTextBody body)
        {
            if(!await _service.ForwradPriviteChat(body))
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
