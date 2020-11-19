using System;
using System.Linq;
using System.Text.Json;
using PhotoAlbum.Service;
using PhotoAlbum.Service.Models;

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


            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var getPhotosService = new HttpGetService<Photo>("https://jsonplaceholder.typicode.com/photos", jsonSerializerOptions);
            var photoAlbumService = new PhotoAlbumService(getPhotosService);

            var photos = photoAlbumService.GetPhotosByAlbumId(validationResult.Result);

            photos.ToList().ForEach((photo) => Console.WriteLine(photo));
        }
    }
}
