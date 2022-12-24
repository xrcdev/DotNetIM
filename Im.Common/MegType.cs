using System;
using System.Collections.Generic;
using System.Text;

namespace Im_Common
{
    /// <summary>
    /// 用来区分消息
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        /// d登录消息
        /// </summary>
            LOGIN,

        /// <summary>
        /// 聊天消息
        /// </summary>
            MSG,

        /// <summary>
        /// 心跳消息
        /// </summary>
            PING,

            /// <summary>
            /// 心跳消息
            /// </summary>
            PONG
    }
}
