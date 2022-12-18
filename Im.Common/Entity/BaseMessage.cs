using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace im.common
{
    
    public class BaseMessage
    {
        /// <summary>
        /// 唯一请求号 保证消息幂等
        /// </summary>
        [Required]
        private string _reqno;

        [Required(ErrorMessage = "用户id不为空！")]
        private long _reqid;
         
        public long Reqid { get => _reqid; set => _reqid = value; }

        public string Reqno { get => _reqno; set => _reqno = value; }
    }
}
