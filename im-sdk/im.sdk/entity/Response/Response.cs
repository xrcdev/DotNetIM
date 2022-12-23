using im.common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.entity.Response
{
    public class Response
    {

        public ApiResultCode Code { get; set; }

        public string? Message { get; set; }


        public bool IsSucess()
        {
            return Code == ApiResultCode.Success;
        }
    }
}
