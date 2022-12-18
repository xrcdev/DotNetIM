using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace im.common
{
    public class MsgStreamBody: BaseMessage
    {
     

        [Required(ErrorMessage = "body不为空！")]
        private Stream _body;

        public Stream Body { get => _body; set => _body = value; }
    }
}
