using IM_server1.Entity;

namespace IM_Router.service
{
    public interface IForwradService
    {

        /// <summary>
        /// 转发私聊消息
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        Task<bool> ForwradPriviteChat(BaseMessage mes);

        /// <summary>
        /// 转发群聊消息
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        Task<bool> ForwradGroupChat(BaseMessage mes);

    }
}
