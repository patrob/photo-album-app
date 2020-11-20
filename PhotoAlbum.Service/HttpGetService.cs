using System;
using System.Net.Http;

namespace PhotoAlbum.Service
{
    /// <summary>
    /// Class for wrapping the HttpClient for ease of mocking
    /// </summary>
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

        public HttpResponseMessage Get(string filterString)
        {
            return httpClient.GetAsync(filterString).Result;
        }
    }
}
