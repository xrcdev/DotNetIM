using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.entity.Request
{
    public class TxtMessageRequest
    {
        public long reqid { get; set; }
        public string Body { get; set; }
        
        public ForwardEnum type { get; set;}

    }
}
