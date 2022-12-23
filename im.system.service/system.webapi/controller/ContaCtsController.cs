using im.common;
using Im.Common.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using system.models;
using system.models.Vo;
using system.service;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace system_webapi.controller
{
    [ApiController]
    [Route("/ContaCts")]
    [Authorize]
    public class ContaCtsController
    {
        private IContaCtsService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContaCtsController(IContaCtsService service, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this._service = service;
        }


        [HttpGet("/getContaCts")]
        public ApiResult<List<UserVo>> getContaCts([Required] int page, [Required] int size)
        {

            string userid = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);


            return new ApiResult<List<UserVo>>()
            {
                Code = ApiResultCode.Success,
                Message = "获取成功",
                Data = _service.GetContaCtsList(int.Parse(userid),page,size)
            };

        }
        [HttpPost ("/addContaCts")]
        public async Task<ApiResult<string>> addContaCts(int Userid, int ContaCtsId)
        {
            if (await _service.AddContaCts(Userid, ContaCtsId))
            {
                return new ApiResult<string>()
                {
                    Code = ApiResultCode.Success,
                    Message = "添加好友成功",
                };
            }
            return new ApiResult<string>()
            {
                Code = ApiResultCode.Failed,
                Message = "你们已经是好友,无法重复添加!",
            };
        }


        /// <summary>
        /// 判断两人是否是好友
        /// </summary>
        /// <param name="UserTag"></param>
        /// <param name="ContaTag"></param>
        /// <returns></returns>
        /// 
        [HttpGet("/IsContaCts")]

        public async Task<ApiResult<string>> IsContaCts(string UserTag, string ContaTag)
        {
            if (await _service.IsContaCtsTag(UserTag, ContaTag))
            {
                return new ApiResult<string>()
                {
                    Code = ApiResultCode.Success,
                    Message = "两人是好友关系"
                };
            }

            return new ApiResult<string>()
            {
                Code = ApiResultCode.Failed,
                Message = "两人非好友关系"
            };
        }


    }

    
}
