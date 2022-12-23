using SqlSugar;
using system.models;
using system.models;
using system.models.Vo;
using system.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system.service.impl
{
    public class ContaCtsService : Repository<ContaCts>, IContaCtsService
    {
        private IUserService _service;
        public ContaCtsService(IUserService service)
        {
            this._service = service;
        }
        public async Task<bool> AddContaCts(int userId, int contaId)
        {
           if(await this.IsContaCts(userId, contaId))
           {
                return false;
           }

           return await base.InsertAsync(new ContaCts()
            {
                Userid = userId,
                ContaCtid=contaId
            });

        }

        public List<UserVo> GetContaCtsList(int userid, int page, int size)
        {

            int start = (page!=0?page-1:page) * size;
            string sql = "select a.id, username, headsrc," +
                "userTag from im_user as a inner join  im_contacts b " +
                "on b.userid=a.id where b.contactid=@userid " +
                "union all select a.id, username, headsrc, userTag from im_user as" +
                " a inner join  im_contacts b on b.contactid=a.id where b.userid=@userid  limit @start,@end" ;
             
            return base.Context.Ado.SqlQuery<UserVo>(sql,new {userid=userid,start=start,end= size }).ToList();
        }

        public async Task<bool> IsContaCts(int userid, int contaId)
        {
            return await base.GetFirstAsync(a => a.Userid == userid || a.ContaCtid == contaId)!=null&&
                         base.GetFirstAsync(a => a.ContaCtid == userid || a.Userid == contaId) != null;
        }

        public async Task<bool> IsContaCtsTag(string userTag, string contaTag)
        {
            User user1 = _service.getUser(userTag);

            User user2= _service.getUser(contaTag);

            return await IsContaCts(user1.Id, user2.Id);
        }
    }
}
