using System.IO;
using System.Linq;
using NSubstitute;
using PhotoAlbum.Service;
using PhotoAlbum.Service.Models;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoAppRunnerTests
    {
        [Fact]
        public void Run_InvalidArgs_WritesValidationDescription()
        {
            var mockTextWriter = Substitute.For<TextWriter>();
            var mockValidationService = Substitute.For<IValidationService>();
            var mockPhotoAlbumService = Substitute.For<IPhotoAlbumService>();

            mockValidationService.GetValidationResult(Arg.Any<string[]>()).Returns(new ValidationResult
            {
                Description = "Invalid Album ID provided.",
                IsValid = false
            });

            var testRunner = new PhotoAppRunner(mockTextWriter, mockValidationService, mockPhotoAlbumService);

            testRunner.Run(new[] { "badArg" });

            mockTextWriter.Received(1).WriteLine("Invalid Album ID provided.");
        }

        [Fact]
        public void Run_ValidArgs_WritesValidationDescription()
        {
            var mockTextWriter = Substitute.For<TextWriter>();
            var mockValidationService = Substitute.For<IValidationService>();
            var mockPhotoAlbumService = Substitute.For<IPhotoAlbumService>();

            mockValidationService.GetValidationResult(Arg.Any<string[]>()).Returns(new ValidationResult
            {
                Description = "Valid",
                IsValid = true,
                Result = 1
            });

            mockPhotoAlbumService.GetPhotosByAlbumId(1).Returns(new GetPhotosResult
            {
                // saving some space by generating a list of photos with numbers 1-10 as id
                Photos = Enumerable.Range(1, 10).Select(n => new Photo { Id = n, Title = "test" }).ToList()
            });

            var testRunner = new PhotoAppRunner(mockTextWriter, mockValidationService, mockPhotoAlbumService);

            testRunner.Run(new[] { "1" });

            mockTextWriter.DidNotReceive().WriteLine("Invalid Album ID provided.");
            // saving space by counting from 1-10
            Enumerable.Range(1, 10).ToList().ForEach((n) => mockTextWriter.Received().WriteLine($"[{n}] test"));
        }
    }
}
