using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk
{
    /// <summary>
    /// 保存请求的路由
    /// </summary>
    internal static class GloableRouteConfig
    {
        private readonly static Dictionary<string, string> RouterCache = new Dictionary<string, string>();

        static GloableRouteConfig(){
            RouterCache.Add("ContsCtsListRequest", "/system/getContaCts");
            RouterCache.Add("LoginRequest", "/system/Login");

        }

        public static string GetOrDefaultValues(string key)
        {
            return RouterCache.GetValueOrDefault<string,string>(key);
        }



    }
}
