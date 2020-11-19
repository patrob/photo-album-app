using System;

namespace PhotoAlbum.Service
{
    public interface IGetService : IDisposable
    {
        string Get(string url);
    }
}
