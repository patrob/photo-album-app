using System;
using System.Collections.Generic;
using System.Text.Json;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private IGetService<Photo> getPhotosService;

        public PhotoAlbumService(IGetService<Photo> getPhotosServiceParam)
        {
            getPhotosService = getPhotosServiceParam;
        }

        public IEnumerable<Photo> GetPhotosByAlbumId(int albumId)
        {
            if (albumId < 0)
            {
                throw new ArgumentException("Invalid Album Id.", nameof(albumId));
            }

            try
            {
                var photos = getPhotosService.Get($"?albumId={albumId}");

                return photos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
