
using SqlSugar;

namespace system.models
{
    public class LoginVo
    {
        public User Userinfo { get; set; }

        public string? Token { get; set; }
    }
}
