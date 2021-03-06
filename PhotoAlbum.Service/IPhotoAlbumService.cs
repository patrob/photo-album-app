﻿using System.Collections.Generic;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public interface IPhotoAlbumService
    {
        GetPhotosResult GetPhotosByAlbumId(int albumId);
    }
}
