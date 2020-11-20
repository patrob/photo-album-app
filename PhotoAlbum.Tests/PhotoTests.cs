using PhotoAlbum.Service.Models;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoTests
    {
        [Fact]
        public void ToString_ValidPhoto_CorrectOutput()
        {
            const int ID = 1;
            const string TITLE = "Some title";

            var photo = new Photo
            {
                Id = 1,
                AlbumId = 5,
                Title = "Some title",
                ThumbnailUrl = "url",
                Url = "url"
            };

            var result = photo.ToString();

            Assert.Equal($"[{ID}] {TITLE}", result);
        }

        [Fact]
        public void ToString_NullTitle_ReturnIdAndMessageReplacingNullTitle()
        {
            const int ID = 1;
            const string TITLE = "No Title Provided";

            var photo = new Photo
            {
                Id = 1,
                AlbumId = 5,
                Title = null,
                ThumbnailUrl = "url",
                Url = "url"
            };

            var result = photo.ToString();

            Assert.Equal($"[{ID}] {TITLE}", result);
        }

        [Fact]
        public void ToString_NegativeId_ReturnMessageNotifyingOfNegativeId()
        {
            const int ID = -1;
            const string TITLE = "Invalid Id";

            var photo = new Photo
            {
                Id = -1,
                AlbumId = 5,
                Title = "title",
                ThumbnailUrl = "url",
                Url = "url"
            };

            var result = photo.ToString();

            Assert.Equal($"[{ID}] {TITLE}", result);
        }
    }
}