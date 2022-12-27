using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.entity.Request
{
   
    public class RegistRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string admin { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string headsrc { get; set; }

    }
}
