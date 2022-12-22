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
        Task<bool> addRoute(long uid, string host);
    }
}
