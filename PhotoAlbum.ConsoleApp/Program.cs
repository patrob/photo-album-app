using System;
using System.Linq;
using PhotoAlbum.Service;

namespace PhotoAlbum.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var validationService = new ValidationService();
            var validationResult = validationService.GetValidationResult(args);

            if (!validationResult.IsValid)
            {
                Console.WriteLine(validationResult.Description);
                return;
            }


            using var getPhotosService = new HttpGetService("https://jsonplaceholder.typicode.com/photos");
            var photoAlbumService = new PhotoAlbumService(getPhotosService);

            var photos = photoAlbumService.GetPhotosByAlbumId(validationResult.Result);

            photos.ToList().ForEach((photo) => Console.WriteLine(photo));
        }
    }
}
