using system.models;
using system.models.Vo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace system.service
{
    public interface IContaCtsService
    {
        /// <summary>
        /// 查询自己的所有好友
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<UserVo> GetContaCtsList(int userid,int page,int size);


        /// <summary>
        /// 添加好友
        /// </summary>
        /// <returns></returns>
        Task<bool> AddContaCts(int userId,int contaId);

        /// <summary>
        /// 判断两人是否为好友
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="contaId"></param>
        /// <returns></returns>
        Task<bool> IsContaCts(int userid,int contaId);


        /// <summary>
        /// 判断两人是否满足好友关系
        /// </summary>
        /// <param name="userTag">用户的usertag</param>
        /// <param name="contaTag">联系人的usertag</param>
        /// <returns></returns>
        Task<bool> IsContaCtsTag(string userTag, string contaTag);
    }
}
