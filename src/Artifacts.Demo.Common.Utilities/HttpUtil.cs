using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Artifacts.Demo.Common.Utilities
{
    public static class HttpUtil<T>
    {
        public static async Task<HttpResponseMessage> Post(string serviceUrl, T message)
        {
            using var client = new HttpClient()
            {
                BaseAddress = new Uri(serviceUrl),
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

            return await client.PostAsync(serviceUrl, content);
        }
    }
}
