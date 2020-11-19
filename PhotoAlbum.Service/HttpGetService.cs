using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace PhotoAlbum.Service
{
    public class HttpGetService<T> : IGetService<T>
    {
        private HttpClient httpClient;
        private JsonSerializerOptions jsonSerializerOptions;

        public HttpGetService(string baseUrl, JsonSerializerOptions jsonSerializerOptionsParam)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            jsonSerializerOptions = jsonSerializerOptionsParam;
        }

        public void Dispose() => httpClient.Dispose();

        public List<T> Get(string filterString)
        {
            var response = httpClient.GetAsync(filterString).Result;
            response.EnsureSuccessStatusCode();
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var result = JsonSerializer.Deserialize<List<T>>(responseJson, jsonSerializerOptions);
            return result;
        }
    }
}
