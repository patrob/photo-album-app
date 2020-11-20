using System.Collections.Generic;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public interface IPhotoService
    {
        List<Photo> GetPhotosByAlbumId(int albumId);
    }
}
