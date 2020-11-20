using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public class PhotoWriter : IPhotoWriter
    {
        private readonly TextWriter output;

        public PhotoWriter(TextWriter textWriter)
        {
            output = textWriter;
        }

        public void WritePhotos(GetPhotosResult photosResult)
        {
            if (photosResult.Photos.Any())
            {
                photosResult.Photos.ForEach((photo) => output.WriteLine($"{photo}"));
            }
            else if (!string.IsNullOrEmpty(photosResult.ErrorMessage))
            {
                output.WriteLine($"Failed to retrieve photos. {photosResult.ErrorMessage}");
            }
            else
            {
                output.WriteLine("No photos.");
            }
        }
    }
}
