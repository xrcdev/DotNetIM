using Nacos.V2;
using StackExchange.Redis;
using System.Threading.Tasks;


namespace Forward.service
{
    public class RouteService: IRouteService
    {
        private INacosNamingService _nacos;
        private RedisHerper _redisHerper;
          
        public RouteService(INacosNamingService nacos,RedisHerper herper)
        {
            this._nacos = nacos;
            this._redisHerper = herper;
        }

        /// <summary>
        /// 向redis 中写入路由信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="host"></param>
        public async Task<bool> AddRoute(string token, string host)
        {
            string key = $"{token}_router";
            return await _redisHerper.SetValue<string>(key,host);
        }

        public async Task<string> getImServer()
        {
            var instance =await _nacos.SelectOneHealthyInstance("im-server", "DEFAULT_GROUP");
            
            return $"{instance.Ip}:{instance.Port}"; 
        }
    }
}
