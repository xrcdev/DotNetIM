using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace im.sdk.untils
{
    internal class HttpClientUtils
    {
        private static HttpClient client = new HttpClient();

        static HttpClientUtils()
        {

            
        }
        /// <summary>
        /// 发送get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns></returns>

        public static async Task<T> Get<T>(string url,string token="")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (!token.Equals(""))
            {
                request.Headers.Add("Authorization", token);
            }
            var response = await client.SendAsync(request);

            var res = await response.Content.ReadAsStringAsync();
         

            return JsonConvert.DeserializeObject<T>(res);
        }

        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <typeparam name="K">body 类型</typeparam>
        /// <param name="url">请求的地址</param>
        /// <param name="body">请求参数</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<T> Post<T, K>(string url, K body,string token="")
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            
            if (!token.Equals(""))
            {
                request.Headers.Add("Authorization", token);
            }
            if (!(body is string))
                request.Content = new StringContent(JsonConvert.SerializeObject(body));
            else
                request.Content = new StringContent(body.ToString());

            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


            var response = await client.SendAsync(request);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        public static async Task<T> Post<T>(string url, string token = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

             if (!token.Equals(""))
            {
                request.Headers.Add("Authorization", token);
            }
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


            var response = await client.SendAsync(request);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

    }
}
