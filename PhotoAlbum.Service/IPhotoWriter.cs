using System;
using System.Collections.Generic;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public interface IPhotoWriter
    {
        void WritePhotos(List<Photo> photos);
    }
}
