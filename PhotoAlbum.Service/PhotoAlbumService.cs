using System;
using System.Collections.Generic;
using System.Text.Json;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private IGetService getPhotosService;

        public PhotoAlbumService(IGetService getPhotosServiceParam)
        {
            getPhotosService = getPhotosServiceParam;
        }

        public IEnumerable<Photo> GetPhotosByAlbumId(int albumId)
        {
            if (albumId < 0)
            {
                throw new ArgumentException("Invalid Album Id.", nameof(albumId));
            }

            var jsonPhotos = getPhotosService.Get($"/photos?albumId={albumId}");
            var photos = JsonSerializer.Deserialize<List<Photo>>(jsonPhotos, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return photos;
        }
    }
}
