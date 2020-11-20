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

        public void WritePhotos(List<Photo> photos)
        {
            if (photos.Any())
            {
                photos.ForEach((photo) => output.WriteLine($"{photo}"));
            }
            else
            {
                output.WriteLine("No photos.");
            }
        }
    }
}
