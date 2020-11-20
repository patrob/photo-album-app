using System;
using System.IO;

namespace PhotoAlbum.Service
{
    public class PhotoAppRunner
    {
        private readonly TextWriter output;
        private readonly IValidationService validationService;
        private readonly IPhotoAlbumService photoAlbumService;

        public PhotoAppRunner(TextWriter textWriter, IValidationService validationServiceParam, IPhotoAlbumService photoAlbumServiceParam)
        {
            output = textWriter;
            validationService = validationServiceParam;
            photoAlbumService = photoAlbumServiceParam;
        }

        public void Run(string[] args)
        {
            var validationResult = validationService.GetValidationResult(args);

            if (!validationResult.IsValid)
            {
                output.WriteLine(validationResult.Description);
                return;
            }

            var photoResult = photoAlbumService.GetPhotosByAlbumId(validationResult.Result);

            var photoWriter = new PhotoWriter(output);

            photoWriter.WritePhotos(photoResult);
        }
    }
}
