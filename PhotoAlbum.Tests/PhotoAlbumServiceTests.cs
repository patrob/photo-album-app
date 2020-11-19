using System;
using System.Collections.Generic;
using System.Text.Json;
using NSubstitute;
using PhotoAlbum.Service;
using PhotoAlbum.Service.Models;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoAlbumServiceTests
    {
        IGetService mockGetService;
        List<Photo> testPhotos;

        public PhotoAlbumServiceTests()
        {
            testPhotos = new List<Photo> {
                new Photo
                {
                    Id = 1,
                    AlbumId = 1,
                    ThumbnailUrl = "url",
                    Title = "the title",
                    Url = "url"
                }
            };
            var jsonResult = JsonSerializer.Serialize(testPhotos, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            mockGetService = Substitute.For<IGetService>();
            mockGetService.Get(Arg.Any<string>()).Returns(jsonResult);
        }

        [Fact]
        public void GetPhotosByAlbumId_ValidId_Returns1Record()
        {
            var albumId = 1;

            var testService = new PhotoAlbumService(mockGetService);
            var photos = testService.GetPhotosByAlbumId(albumId);

            Assert.Single(photos);
        }

        [Fact]
        public void GetPhotosByAlbumId_InvalidId_ThrowsException()
        {
            var albumId = -1;

            var testService = new PhotoAlbumService(mockGetService);
            var ex = Assert.Throws<ArgumentException>(() => testService.GetPhotosByAlbumId(albumId));

            Assert.NotNull(ex);
            Assert.Contains("Invalid Album Id.", ex.Message);
        }
    }
}
