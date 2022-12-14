namespace IM_server1.Entity.Result
{
    public class ApiResult<T>
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public ApiResultCode Code { get; set; }
        /// <summary>
        /// 错误信息 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 具体数据
        /// </summary>
        public T Data { get; set; }
    }
}
