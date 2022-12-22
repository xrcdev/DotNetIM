using im.common;
using system.models;
using system.service;

namespace system_webapi.controller
{
    public class ContaCtsController
    {
        private IContaCtsService _service;
        public ContaCtsController(IContaCtsService service)
        {
            this._service = service;
        }

        public ApiResult<List<ContaCts>> getContaCts()
        {
            int userid = 1;

            return new ApiResult<List<ContaCts>>()
            {
                Code = ApiResultCode.Success,
                Message = "获取成功",
                Data = _service.GetContaCtsList(userid)
            };

        }

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
