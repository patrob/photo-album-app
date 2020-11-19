using PhotoAlbum.Service.Models;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoTests
    {
        [Fact]
        public void ToString_ValidPhoto_CorrectOutput()
        {
            var photo = new Photo
            {
                Id = 1,
                AlbumId = 5,
                Title = "Some title",
                ThumbnailUrl = "url",
                Url = "url"
            };

            var result = photo.ToString();

            Assert.Equal("[1] Some title", result);
        }

        [Fact]
        public void ToString_NullTitle_CorrectOutput()
        {
            var photo = new Photo
            {
                Id = 1,
                AlbumId = 5,
                Title = null,
                ThumbnailUrl = "url",
                Url = "url"
            };

            var result = photo.ToString();

            Assert.Equal("[1] ", result);
        }

        [Fact]
        public void ToString_NegativeId_CorrectOutput()
        {
            var photo = new Photo
            {
                Id = -1,
                AlbumId = 5,
                Title = "title",
                ThumbnailUrl = "url",
                Url = "url"
            };

            var result = photo.ToString();

            Assert.Equal("[-1] title", result);
        }
    }
}