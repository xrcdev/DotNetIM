using im.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Im.Common.component
{
    public class HttpClientComponent: IHttpClientComponent
    {
        private IHttpClientFactory _factory;
        public HttpClientComponent(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<T> Get<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);


            var client = _factory.CreateClient();

            var response = await client.SendAsync(request);

            var res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(res);
        }

        public async Task<T> Post<T,K>(string url, K body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if(!(body is string))
                request.Content = new StringContent(JsonConvert.SerializeObject(body));
            else
                request.Content = new StringContent(body.ToString());

            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var client = _factory.CreateClient();
             
            var response = await client.SendAsync(request);
             
            return  JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        public async Task<T> Post<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);


            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var client = _factory.CreateClient();

            var response = await client.SendAsync(request);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
