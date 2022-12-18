using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IM_server1.Entity
{
    public class MsgTextBody: BaseMessage
    {

        [Required(ErrorMessage = "文本消息不为空！")]
        private string _body;

        public string Body { get => _body; set => _body = value; }
    }
}
