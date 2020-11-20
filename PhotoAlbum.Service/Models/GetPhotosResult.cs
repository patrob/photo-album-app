using System.Collections.Generic;

namespace PhotoAlbum.Service.Models
{
    public class GetPhotosResult
    {
        public List<Photo> Photos { get; set; }
        public string ErrorMessage { get; set; }
    }
}
