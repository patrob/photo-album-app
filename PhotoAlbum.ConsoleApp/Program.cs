using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PhotoAlbum.Service;

namespace PhotoAlbum.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var validationService = new ValidationService();
            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var httpClientWrapper = new HttpGetService(configuration["PhotosUrl"]);
            var photoService = new PhotoService(httpClientWrapper, jsonSerializerOptions);
            var photoAlbumService = new PhotoAlbumService(photoService);
            var photoAppRunner = new PhotoAppRunner(Console.Out, validationService, photoAlbumService);
            photoAppRunner.Run(args);
        }
    }
}
