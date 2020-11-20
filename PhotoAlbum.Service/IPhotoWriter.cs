using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public interface IPhotoWriter
    {
        void WritePhotos(GetPhotosResult photosResult);
    }
}
