using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.entity.Request
{
    /// <summary>
    /// 查询时需要的操作
    /// </summary>
    public class GetRequest
    {
        public string token { get; set; }

        public int page { get; set; }

        public int size { get; set; }
    }
}
