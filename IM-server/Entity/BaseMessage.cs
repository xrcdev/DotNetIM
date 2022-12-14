using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IM_server1.Entity
{
    
    public class BaseMessage
    {
        /// <summary>
        /// 唯一请求号 保证消息幂等
        /// </summary>
        [Required]
        private String _reqno;

        [Required(ErrorMessage = "用户id不为空！")]
        private int _reqid;


        public int Reqid { get => _reqid; set => _reqid = value; }

        public string Reqno { get => _reqno; set => _reqno = value; }
    }
}
