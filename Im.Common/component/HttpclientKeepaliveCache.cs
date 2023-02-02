using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Im.Common.component
{
    public class httpClientKeepaliveCache
    {
        private  Dictionary<string, HttpClient> keepalivekv
                                                       = new Dictionary<string, HttpClient>();
        private IHttpClientFactory _factory;
        public httpClientKeepaliveCache(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public HttpClient GetClientKeepalive(string url)
        {
            string host = getHost(url);

            if (string.IsNullOrEmpty(host))
            {
                return null;
            }
            HttpClient _client;

            if ((_client = keepalivekv.GetValueOrDefault<string, HttpClient>(host, null)) == null)
            {
                return newHttpClient(host);
            }
            return _client;

        }
        private HttpClient newHttpClient(string key)
        {
            var _httpClient = _factory.CreateClient();

            _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

            keepalivekv.Add(key, _httpClient);

            return _httpClient;
        }
        string getHost(string url)
        {
            String host = "";
            string strPatten = "(?<=//|)((\\w)+\\.)+\\w+";
            Regex rex = new Regex(strPatten, RegexOptions.IgnoreCase);
            MatchCollection matches = rex.Matches(url);
            if (matches.Count > 1)
            {
                host = matches[0].Value;
            }

            return host;
        }
    }
}
