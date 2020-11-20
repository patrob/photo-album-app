using System;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private IPhotoService getPhotosService;

        public PhotoAlbumService(IPhotoService getPhotosServiceParam)
        {
            getPhotosService = getPhotosServiceParam;
        }

        public GetPhotosResult GetPhotosByAlbumId(int albumId)
        {
            if (albumId < 0)
            {
                throw new ArgumentException("Invalid Album Id.", nameof(albumId));
            }

            try
            {
                var photos = getPhotosService.GetPhotosByAlbumId(albumId);

                return new GetPhotosResult
                {
                    Photos = photos
                };
            }
            catch (Exception ex)
            {
                return new GetPhotosResult
                {
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
