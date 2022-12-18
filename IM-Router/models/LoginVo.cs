using Models;
using SqlSugar;

namespace IM_Router.models
{
    public class LoginVo
    {
        public User Userinfo { get; set; }

        public string? Token { get; set; }
    }
}
