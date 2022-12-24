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
        private readonly static Dictionary<string, string> routerCache = new Dictionary<string, string>();

        static GloableRouteConfig(){
            routerCache.Add("ContsCtsListRequest", "/system/getContaCts");
            routerCache.Add("LoginRequest", "/system/Login");
            routerCache.Add("ImServerAddrRequest", "/forward/getNode");

        }

        public static string GetOrDefaultValues(string key)
        {
            return routerCache.GetValueOrDefault<string,string>(key);
        }



    }
}
