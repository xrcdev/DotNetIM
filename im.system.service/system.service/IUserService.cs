using service;
using system.models;
using System.Threading.Tasks;

namespace system.service
{
    public interface IUserService
    {
        Task<LoginVo?> Login(string UserName, string password);
        bool Logout();
       
        Task<bool> Regist(User user);

        User getUser(string userTag);
    }
}
