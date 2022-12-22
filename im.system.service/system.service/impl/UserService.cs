using service.untils;
using system.models;
using system.repository;
using system.service;
using system.untils;
using System;
using System.Threading.Tasks;

namespace service
{
    public class UserService : Repository<User>,IUserService
    {
        private TokenManager _manage;
        public UserService(TokenManager manager)
        {
            this._manage = manager;
        }

        public User getUser(string userTag)
        {
            return base.GetFirst(a => a.UserTag == userTag);
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

        public async Task<User> ParserToken(string token)
        {
             return await _manage.getUser(token);
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
