using System;
using System.Net.Http;

namespace PhotoAlbum.Service
{
    public interface IGetService : IDisposable
    {
        HttpResponseMessage Get(string filterString);
    }
}
