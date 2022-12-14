
using DotNetty.Transport.Channels;
using System.Threading.Channels;

namespace IM_server1.cache
{
    /// <summary>
    /// 保存当前节点所有在线用户
    /// </summary>
    public static class SessionCache
    {
        private static Dictionary<int, IChannel> cache = new Dictionary<int, IChannel>();

        private static Dictionary<int, String> sessionMap = new Dictionary<int, string>();
        public static void Put(int pid,IChannel channel)
        {
            cache[pid] = channel;
        }

        public static void SaveSession(int id,String body)
        {
            sessionMap[id] = body;
        }

        public static IChannel? GetChannel(int id)
        {
            return cache.GetValueOrDefault<int, IChannel>(id);
        }

    }
}
