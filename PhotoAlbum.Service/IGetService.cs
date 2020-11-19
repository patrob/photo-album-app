using System;
using System.Collections.Generic;

namespace PhotoAlbum.Service
{
    public interface IGetService<T> : IDisposable
    {
        List<T> Get(string filterString);
    }
}
