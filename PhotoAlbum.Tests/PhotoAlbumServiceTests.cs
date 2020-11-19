using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using PhotoAlbum.Service;
using PhotoAlbum.Service.Models;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoAlbumServiceTests
    {
        IGetService<Photo> mockGetService;
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
            mockGetService = Substitute.For<IGetService<Photo>>();
            mockGetService.Get(Arg.Any<string>()).Returns(testPhotos);
        }

        [Fact]
        public void GetPhotosByAlbumId_ValidId_ReturnsExpectedCount()
        {
            var albumId = 1;
            var expectedCount = testPhotos.Count;

            var testService = new PhotoAlbumService(mockGetService);
            var photos = testService.GetPhotosByAlbumId(albumId);

            Assert.Equal(expectedCount, photos.Count());
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
