using System;
using System.Threading.Tasks;

namespace Forward.service
{


    public interface IRouteService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid">唯一id</param>
        /// <param name="host">对应在线主机</param>
        Task<bool> AddRoute(string token,String host);


        /// <summary>
        /// 从注册中心中获得一个im节点地址
        /// </summary>
        /// <returns></returns>
        Task<string> getImServer();
    }
}
