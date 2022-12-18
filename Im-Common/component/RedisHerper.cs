using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System.Threading.Tasks;

namespace IM_Router.untils
{
    public class RedisHerper
    {
        private IRedisDatabase DB { get; set; }
        public RedisHerper(IRedisClient cli) => DB = cli.Db0;

        /// <summary>
        /// 增加/修改
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public  async Task<bool> SetValue<T>(string key, T value)
        {
            return await DB.AddAsync<T>(key, value);
        }
 

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetValue<T>(string key)
        {
            return await DB.GetAsync<T>(key);
        }

    }
}
