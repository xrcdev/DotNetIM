using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace im.common
{
    public class MsgTextBody: BaseMessage
    {

        [Required(ErrorMessage = "文本消息不为空！")]
        private string _body;

        public string Body { get => _body; set => _body = value; }
    }
}
