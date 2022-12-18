
using SqlSugar;

namespace service.models
{
    public class LoginVo
    {
        public User Userinfo { get; set; }

        public string? Token { get; set; }
    }
}
