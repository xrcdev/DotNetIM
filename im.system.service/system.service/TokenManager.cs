﻿using Im.Common.Entity;
using OracleInternal.Secure.Network;
using SqlSugar.DistributedSystem.Snowflake;
using system.models;
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
            var vo = new TokenVo()
            {
                userTag = u.UserTag,
                id=u.Id,
                admin=u.Username

            };
            await _herper.SetValue<TokenVo>(token, vo);

            
            return token;
        }

        /// <summary>
        /// 根据token获得用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<TokenVo?> getUser(string token)
        {
            return await _herper.GetValue<TokenVo>(token);
        }
    }
}
