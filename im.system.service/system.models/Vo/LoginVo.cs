
using SqlSugar;

namespace system.models.Vo
{
    public class LoginVo
    {
        public UserVo user { get; set; }

        public string? Token { get; set; }
    }
}
