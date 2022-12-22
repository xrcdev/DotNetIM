
using DotNetty.Transport.Channels;
using System.Threading.Channels;

namespace dotnetty.webapi.cache
{
    /// <summary>
    /// 保存当前节点所有在线用户
    /// </summary>
    public static class SessionCache
    {
        private static Dictionary<long, IChannel> cache = new Dictionary<long, IChannel>();

        private static Dictionary<long, String> sessionMap = new Dictionary<long, string>();
        public static void Put(long pid,IChannel channel)
        {
            cache[pid] = channel;
        }

        public static void SaveSession(long id,String body)
        {
            sessionMap[id] = body;
        }

        public static IChannel? GetChannel(long id)
        {
            return cache.GetValueOrDefault<long, IChannel>(id);
        }

    }
}
