using im.common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Im.Common.component
{
    public interface IHttpClientComponent
    {
        Task<T> Post<T, K>(string url, K json);
        Task<T> Post<T>(string url);

        Task<T> Get<T>(string url);
    }
}
