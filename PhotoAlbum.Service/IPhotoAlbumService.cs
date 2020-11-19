using System.Collections.Generic;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public interface IPhotoAlbumService
    {
        IEnumerable<Photo> GetPhotosByAlbumId(int albumId);
    }
}
