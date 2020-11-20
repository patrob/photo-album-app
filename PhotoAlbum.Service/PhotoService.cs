using System.Collections.Generic;
using System.Text.Json;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly IGetService getService;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        public PhotoService(IGetService getServiceParam, JsonSerializerOptions jsonSerializerOptionsParam)
        {
            getService = getServiceParam;
            jsonSerializerOptions = jsonSerializerOptionsParam;
        }

        public List<Photo> GetPhotosByAlbumId(int albumId)
        {
            var response = getService.Get($"?albumId={albumId}");
            response.EnsureSuccessStatusCode();
            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Photo>>(responseJson, jsonSerializerOptions);
        }
    }
}
