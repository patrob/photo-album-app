using System;
using System.Collections.Generic;
using NSubstitute;
using PhotoAlbum.Service;
using PhotoAlbum.Service.Models;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoAlbumServiceTests
    {
        IPhotoService mockPhotoService;
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
            mockPhotoService = Substitute.For<IPhotoService>();
        }

        [Fact]
        public void GetPhotosByAlbumId_ValidId_ReturnsExpectedCount()
        {
            var albumId = 1;
            var expectedCount = testPhotos.Count;
            mockPhotoService.GetPhotosByAlbumId(Arg.Any<int>()).Returns(testPhotos);

            var testService = new PhotoAlbumService(mockPhotoService);
            var photoResult = testService.GetPhotosByAlbumId(albumId);

            Assert.Equal(expectedCount, photoResult.Photos.Count);
        }

        [Fact]
        public void GetPhotosByAlbumId_InvalidId_ThrowsException()
        {
            var albumId = -1;
            const string EXCEPTION_MESSAGE = "Invalid Album Id.";
            mockPhotoService.GetPhotosByAlbumId(Arg.Any<int>()).Returns(testPhotos);

            var testService = new PhotoAlbumService(mockPhotoService);
            var ex = Assert.Throws<ArgumentException>(() => testService.GetPhotosByAlbumId(albumId));

            Assert.NotNull(ex);
            Assert.Contains(EXCEPTION_MESSAGE, ex.Message);
        }
    }
}
