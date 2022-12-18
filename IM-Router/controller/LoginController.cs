using Im_Common.Entity;
using IM_Router.models;
using IM_Router.service;
using IM_Router.Service;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;

namespace IM_Router.Controller
{
    [ApiController]
    public class LoginController
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="admin">用户名</param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("/Login")]
        [HttpPost]
        public async Task<ApiResult<LoginVo>> Login([Required(ErrorMessage ="用户名不为空")] string admin, 
                                                    [Required(ErrorMessage = "密码不为空")] string password)
        {

            LoginVo? res = await _userService.Login(admin, password);

            if (res == null) { 
                return 
                    new ApiResult<LoginVo>()
                {
                    Code =ApiResultCode.Failed,
                    Message = "账号获取密码错误！"
                };
            }

            return
                   new ApiResult<LoginVo>()
                   {
                       Code = ApiResultCode.Success,
                       Message = "登录成功！",
                       Data = res
                   };
        }

        [Route("/register")]
        [HttpPost]
        public async Task<ApiResult<string>> register([FromBody] User user)
        { 

            bool res =await _userService.Regist(user);
             
            return new ApiResult<string>()
            {
                Code = res ? ApiResultCode.Success :
                          ApiResultCode.Failed,
                Message = res ? "注册成功" : "当前用户已经存在！！"
            };
        }


    }
}
