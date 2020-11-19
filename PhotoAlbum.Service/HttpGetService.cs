using System;
using System.Net.Http;

namespace PhotoAlbum.Service
{
    public class HttpGetService : IGetService
    {
        private HttpClient httpClient;

        public HttpGetService(string baseUrl)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public void Dispose() => httpClient.Dispose();

        /// <summary>
        /// Gets json data from endpoint.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return responseBody;
        }
    }
}
