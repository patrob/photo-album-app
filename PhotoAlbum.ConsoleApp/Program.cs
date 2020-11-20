using System;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
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

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Console.WriteLine($"Url: {configuration["PhotosUrl"]}");

            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var getPhotosService = new HttpGetService<Photo>(configuration["PhotosUrl"], jsonSerializerOptions);
            var photoAlbumService = new PhotoAlbumService(getPhotosService);

            var photos = photoAlbumService.GetPhotosByAlbumId(validationResult.Result).ToList();

            if (photos.Any())
            {
                photos.ForEach((photo) => Console.WriteLine(photo));
            }
            else
            {
                Console.WriteLine($"No photos returned for Album Id {validationResult.Result}.");
            }
        }
    }
}
