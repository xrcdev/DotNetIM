using OracleInternal.Secure.Network;
using service.models;
using SqlSugar.DistributedSystem.Snowflake;
using system.untils;
using System.Threading.Tasks;
using IdWorker = system.untils.IdWorker;

namespace service.untils
{

    public class TokenManager
    {
        private RedisHerper _herper;

        public TokenManager(RedisHerper herper)
        {
            _herper = herper;
        }
        private long IdGengenerate()
        {
            IdWorker idworker = new IdWorker(1);
            return idworker.nextId();
        }
        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public async Task<string> CreateToken(User u)
        {
            string token = Md5Untils.GetMD5_16(IdGengenerate().ToString());
            await _herper.SetValue<User>(token, u);

            
            return token;
        }

        /// <summary>
        /// 根据token获得用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<User?> getUser(string token)
        {
            return await _herper.GetValue<User>(token);
        }
    }
}
