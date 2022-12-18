using IM_Router.Dao;
using IM_Router.models;
using IM_Router.service;
using IM_Router.untils;
using Models;
using StackExchange.Redis.Extensions.Core.Implementations;

namespace IM_Router.Service.impl
{
    public class UserService : Repository<User>,IUserService
    {
        private TokenManager _manage;
        public UserService(TokenManager manager)
        {
            this._manage = manager;
        }

        public async Task<LoginVo?> Login(string UserName, string password)
        {
            var user = base.GetFirst(a => a.Username == UserName &&
                    a.Password == password);

            if (user == null) return null;

            return new LoginVo()
            {
                Token = await _manage.CreateToken(user),
                Userinfo = user
            };

        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Regist(User user)
        {   
            
            if (base.GetList(a => a.Username == user.Username).Count >0)
                return false;

                IdWorker idworker = new IdWorker(1);
                user.UserTag = idworker.nextId().ToString();
            return await base.InsertAsync(user);
        }
    }
}
