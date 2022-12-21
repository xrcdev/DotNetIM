using Models;
using system.models;
using system.repository;
using System;
using System.Collections.Generic;
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

        public List<ContaCts> GetContaCtsList(int userid)
        {
            var list= base.GetList(a => a.Userid == userid || a.ContaCtid == userid);

            return list;
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
