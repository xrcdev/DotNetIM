using IM_Router.models;
using Models;

namespace IM_Router.service
{
    public interface IUserService
    {
        Task<LoginVo?> Login(string UserName, string password);
        bool Logout();
       
        Task<bool> Regist(User user);
    }
}
