namespace dotnetty.webapi.server
{
    /// <summary>
    /// 调用forward 微服务
    /// </summary>
    public interface IRemoteForwardService
    {
        /// <summary>
        /// 调用一条路由
        /// </summary>
        /// <returns></returns>
        Task<bool> AddRoute(long uid, string host);


        /// <summary>
        /// 删除一条远程路由
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        Task<bool> ClearRouter(long uid);
    }
}
