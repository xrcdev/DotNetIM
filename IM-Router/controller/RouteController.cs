using Im_Common.Entity;
using IM_Router.service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IM_Router.Controller
{
    [ApiController]
    [Route("/router")]
    public class RouteController
    {

        private IRouteService _service;
        
        
        public RouteController(IRouteService service)
        {
            this._service = service;
        }


        /// <summary>
        /// 获取一个imserver节点
        /// </summary>
        /// <returns></returns>
        [HttpGet("/getImServer")]
        public async Task<ApiResult<string>> getImServerAddr()
        {
            string host =await _service.getImServer();

            if (host == null)
            {
                return new ApiResult<string>()
                {
                    Code = ApiResultCode.Failed,
                    Message = "获取失败"
                };
            }

            return new ApiResult<string>()
            {
                Code = ApiResultCode.Success,
                Message = "获取成功",
                Data = host
            };
        }


        /// <summary>
        /// 添加路由
        /// </summary>
        /// <param name="uid">用户唯一id</param>
        /// <param name="host">当前链接的主机</param>
        /// <returns></returns>
        [HttpPost("/addRoute")]
        public async Task<ApiResult<string>> addRouter([Required] string uid,
                                                       [Required] string host)
        {
            if (!await _service.AddRoute(uid, host))
            {
                return new ApiResult<string>()
                {
                    Code = ApiResultCode.Failed,
                    Message = "添加失败"
                };
            }


            return new ApiResult<string>()
            {
                Code = ApiResultCode.Failed,
                Message = "路由添加成功"
            };
        }
    }
}
